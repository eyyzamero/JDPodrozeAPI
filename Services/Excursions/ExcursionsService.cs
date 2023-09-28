using AutoMapper;
using AutoMapper.QueryableExtensions;
using JDPodrozeAPI.Core.Contexts.Excursions;
using JDPodrozeAPI.Core.DTOs;
using JDPodrozeAPI.Core.DTOs.Excursions;
using JDPodrozeAPI.Core.Enums;
using JDPodrozeAPI.Services.Excursions.Contracts.Requests;
using JDPodrozeAPI.Services.Excursions.Contracts.Responses;
using JDPodrozeAPI.Services.Excursions.Exceptions;
using JDPodrozeAPI.Services.Orders;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace JDPodrozeAPI.Services.Excursions
{
    public class ExcursionsService : IExcursionsService
    {
        private readonly IMapper _mapper;
        private readonly ExcursionsDbContext _excursionsDbContext;
        private readonly IEmailsService _emailsService;

        public ExcursionsService(IMapper mapper, ExcursionsDbContext excursionsDbContext, IEmailsService emailsService)
        {
            _mapper = mapper;
            _excursionsDbContext = excursionsDbContext;
            _emailsService = emailsService;
        }

        public async Task<IExcursionsServiceGetImageRes> GetImage(int fileId)
        {
            ExcursionImageDTO image = await _excursionsDbContext.ExcursionsImages.FirstOrDefaultAsync(x => x.Id == fileId) ?? throw new ImageNotFoundException();
            IExcursionsServiceGetImageRes response = _mapper.Map<ExcursionsServiceGetImageRes>(image);
            return response;
        }

        public IExcursionsServiceGetListRes GetList()
        {
            List<ExcursionsServiceGetListItemRes> excursions = _excursionsDbContext.Excursions.Include(x => x.Images).ProjectTo<ExcursionsServiceGetListItemRes>(_mapper.ConfigurationProvider).ToList();

            foreach (ExcursionsServiceGetListItemRes excursion in excursions)
                excursion.Images = excursion.Images.OrderBy(x => x.Order).ToList();

            IExcursionsServiceGetListRes response = new ExcursionsServiceGetListRes { Items = excursions };
            return response;
        }

        public IExcursionsServiceGetListShortRes GetListShort()
        {
            IList<ExcursionDTO> excursions = _excursionsDbContext.Excursions.Where(x => x.Active).OrderBy(x => x.DateFrom).ToList();
            IExcursionsServiceGetListShortRes response = _mapper.Map<ExcursionsServiceGetListShortRes>(excursions);

            foreach (var excursion in response.Items)
                excursion.ImageId = _excursionsDbContext.ExcursionsImages.Where(i => i.ExcursionId == excursion.Id).OrderBy(x => x.Order).Select(i => i.Id).FirstOrDefault();

            return response;
        }

        public IExcursionsServiceGetItemRes? GetItem(int id)
        {
            IExcursionsServiceGetItemRes? response = null;
            ExcursionDTO? excursion = _excursionsDbContext.Excursions.Include(x => x.Images).SingleOrDefault(x => x.Id == id);

            if (excursion != null)
            {
                excursion.Images = excursion.Images.OrderBy(x => x.Order).ToList();
                response = _mapper.Map<ExcursionsServiceGetItemRes>(excursion);
            }
            return response;
        }

        public void Add(ExcursionsServiceAddReq request)
        {
            ExcursionDTO excursion = _mapper.Map<ExcursionDTO>(request);
            _excursionsDbContext.Excursions.Add(excursion);
            _excursionsDbContext.SaveChanges();

            for (int i = 0; i < request.Images.Count; i++)
            {
                ExcursionImageDTO mappedImage = _mapper.Map<ExcursionImageDTO>(request.Images[i]);
                mappedImage.ExcursionId = excursion.Id;
                mappedImage.ImageData = ResizeImageBase64(mappedImage.ImageData);
                mappedImage.Order = i + 1;
                _excursionsDbContext.ExcursionsImages.Add(mappedImage);
            }
            _excursionsDbContext.SaveChanges();
        }

        public void Edit(ExcursionsServiceEditReq request)
        {
            ExcursionDTO excursion = _mapper.Map<ExcursionDTO>(request);
            _excursionsDbContext.Excursions.Update(excursion);
            _excursionsDbContext.SaveChanges();

            _DeleteMarkedImages(request);
            _excursionsDbContext.SaveChanges();

            _AddNewImages(request, excursion.Id);
            _excursionsDbContext.SaveChanges();

            _UpdateImagesOrder(request);
            _excursionsDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _excursionsDbContext.Excursions.Where(x => x.Id == id).ExecuteDelete();
            _excursionsDbContext.SaveChanges();
        }

        public Guid? Enroll(IExcursionsServiceEnrollReq request)
        {
            ExcursionOrderDTO order = _mapper.Map<ExcursionOrderDTO>(request);
            ExcursionDTO excursion = _excursionsDbContext.Excursions.Single(x => x.Id == request.ExcursionId);

            // Adding Order
            _excursionsDbContext.ExcursionsOrders.Add(order);
            _excursionsDbContext.SaveChanges();

            // Adding Booker
            ExcursionParticipantDTO booker = _mapper.Map<ExcursionParticipantDTO>(request.Booker);
            booker.OrderId = order.OrderId;
            _excursionsDbContext.ExcursionsParticipants.Add(booker);
            _excursionsDbContext.SaveChanges();

            // Updating order so there's a booker's id and price
            order.BookerId = booker.Id;

            int bookerDiscountCount = request.Booker.Discount ? 1 : 0;
            int participantsDiscountCount = request.Participants.Where(x => x.Discount).Count();
            decimal withoutDiscountPrice = (1 - bookerDiscountCount + request.Participants.Count() - participantsDiscountCount) * excursion.PriceGross;
            decimal withDiscountPrice = (bookerDiscountCount + participantsDiscountCount) * excursion.DiscountPriceGross;
            order.Price = withoutDiscountPrice + withDiscountPrice;

            _excursionsDbContext.ExcursionsOrders.Update(order);
            _excursionsDbContext.SaveChanges();

            // Adding participants
            if (request.Participants.Count() > 0)
            {
                List<ExcursionParticipantDTO> participants = _mapper.Map<List<ExcursionsServiceEnrollPersonReq>, List<ExcursionParticipantDTO>>(request.Participants);
                participants.ForEach(participant =>
                {
                    participant.BookerId = booker.Id;
                    participant.OrderId = order.OrderId;
                });
                _excursionsDbContext.ExcursionsParticipants.AddRange(participants);
                _excursionsDbContext.SaveChanges();
            }

            // Send email with confirmation of booking submission with payment details
            if (request.PaymentMethod == PaymentMethod.TRADITIONAL_TRANSFER)
            {
                _emailsService.SendEmail(
                    email: booker.Email!,
                    senderDetails: $"{booker.Name} {booker.Surname}",
                    subject: "Potwierdzenie złożenia rezerwacji",
                    body: OrdersEmailsTemplates.GetOrderConfirmationOfBookingSubmissionTraditionalTransfer(excursion.Title, booker.Surname, order.Price),
                    includeLogo: true
                );
                return null;
            }
            return order.OrderId;
        }

        public byte[] ResizeImageBase64(byte[] imageBytes)
        {
            using (var ms = new MemoryStream(imageBytes))
            {
                Image img = Image.FromStream(ms);

                int originalWidth = img.Width;
                int originalHeight = img.Height;
                int newWidth;
                int newHeight;

                double targetRatio = 16.0 / 9.0;
                double originalImageRatio = originalWidth / originalHeight;

                if (originalImageRatio > targetRatio)
                {
                    newWidth = 1280;
                    newHeight = (int)(newWidth / originalImageRatio);
                }
                else
                {
                    newHeight = 720;
                    newWidth = (int)(newHeight * originalImageRatio);
                }

                var newImage = new Bitmap(newWidth, newHeight);

                using (var graphics = Graphics.FromImage(newImage))
                {
                    graphics.DrawImage(img, 0, 0, newWidth, newHeight);
                }

                using (var mstream = new MemoryStream())
                {
                    newImage.Save(mstream, img.RawFormat);
                    byte[] imageArray = mstream.ToArray();

                    return imageArray;
                }
            }
        }

        private void _DeleteMarkedImages(ExcursionsServiceEditReq request)
        {
            List<int> idsToDelete = request.Images.Where(x => x.Deleted).Select(x => x.Id).ToList();
            List<ExcursionImageDTO> imagesToDelete = _excursionsDbContext.ExcursionsImages.Where(x => idsToDelete.Contains(x.Id)).ToList();

            if (imagesToDelete.Any())
                _excursionsDbContext.ExcursionsImages.RemoveRange(imagesToDelete);
        }

        private void _AddNewImages(ExcursionsServiceEditReq request, int excursionId)
        {
            foreach (var imageReq in request.Images.Where(x => x.Id == 0 && !x.Deleted))
            {
                ExcursionImageDTO mappedImage = _mapper.Map<ExcursionImageDTO>(imageReq);
                mappedImage.ExcursionId = excursionId;
                mappedImage.ImageData = ResizeImageBase64(mappedImage.ImageData);
                _excursionsDbContext.ExcursionsImages.Add(mappedImage);
            }
        }

        private void _UpdateImagesOrder(ExcursionsServiceEditReq request)
        {
            List<int> idsToUpdate = request.Images.Where(x => x.Id != 0 && !x.Deleted).Select(x => x.Id).ToList();
            List<ExcursionImageDTO> imagesToUpdate = _excursionsDbContext.ExcursionsImages.Where(x => idsToUpdate.Contains(x.Id)).ToList();

            foreach (var image in imagesToUpdate)
            {
                image.Order = request.Images.First(x => x.Id == image.Id).Order;
                _excursionsDbContext.ExcursionsImages.Update(image);
            }
        }
    }
}