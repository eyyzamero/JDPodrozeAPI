using AutoMapper;
using AutoMapper.QueryableExtensions;
using JDPodrozeAPI.Controllers.Excursions.Contracts.Requests;
using JDPodrozeAPI.Core.Contexts.Excursions;
using JDPodrozeAPI.Core.DTOs;
using JDPodrozeAPI.Core.DTOs.Excursions;
using JDPodrozeAPI.Core.Enums;
using JDPodrozeAPI.Services.Excursions.Contracts.Requests;
using JDPodrozeAPI.Services.Excursions.Contracts.Responses;
using JDPodrozeAPI.Services.Excursions.Enums;
using JDPodrozeAPI.Services.Orders;
using Microsoft.EntityFrameworkCore;

namespace JDPodrozeAPI.Services.Excursions
{
    public class ExcursionsService : IExcursionsService
    {
        private readonly IMapper _mapper;
        private readonly ExcursionsDbContext _excursionsDbContext;
        private readonly IEmailsService _emailsService;
        private readonly IImagesService _imagesService;

        public ExcursionsService(IMapper mapper, ExcursionsDbContext excursionsDbContext, IEmailsService emailsService, IImagesService imagesService)
        {
            _mapper = mapper;
            _excursionsDbContext = excursionsDbContext;
            _emailsService = emailsService;
            _imagesService = imagesService;
        }

        public async Task<byte[]> GetImageNew(int fileId, string resolution, string extension)
        {
            byte[] response = await _imagesService.GetImageAsync("Excursions", fileId, resolution, extension);
            return response;
        }

        public IExcursionsServiceGetListRes GetList(IExcursionsGetListReq request)
        {
            IQueryable<ExcursionDTO> excursionsQuery = _excursionsDbContext.Excursions
                .Include(x => x.Images);

            if (request.Active != null)
                excursionsQuery = excursionsQuery.Where(excursion => (bool) request.Active ? excursion.Active : !excursion.Active);

            switch(request.Sort)
            {
                case ExcursionsSortType.DATE_FROM:
                    excursionsQuery = excursionsQuery.OrderBy(excursion => excursion.DateFrom);
                    break;
                case ExcursionsSortType.DATE_TO:
                    excursionsQuery = excursionsQuery.OrderBy(excursion => excursion.DateTo);
                    break;
            }

            List<ExcursionsServiceGetListItemRes> excursions = excursionsQuery
                .ProjectTo<ExcursionsServiceGetListItemRes>(_mapper.ConfigurationProvider)
                .ToList();

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

        public async Task<IExcursionsServiceGetItemRes?> GetItem(int id, bool images)
        {
            IExcursionsServiceGetItemRes? response = null;
            ExcursionDTO? excursion = _excursionsDbContext.Excursions.Include(x => x.Images).SingleOrDefault(x => x.Id == id);

            if (excursion != null)
            {
                excursion.Images = excursion.Images.OrderBy(x => x.Order).ToList();
                response = _mapper.Map<ExcursionsServiceGetItemRes>(excursion);

                if (images)
                {
                    foreach (var image in response.Images)
                    {
                        byte[] imageBytes = await _imagesService.GetImageAsync("Excursions", image.Id, "HD", "png");
                        image.Base64 = Convert.ToBase64String(imageBytes);
                    }
                }
            }
            return response;
        }

        public async Task Add(ExcursionsServiceAddReq request)
        {
            ExcursionDTO excursion = _mapper.Map<ExcursionDTO>(request);

            _excursionsDbContext.Excursions.Add(excursion);
            _excursionsDbContext.SaveChanges();

            List<ExcursionImageDTO> images = new();

            for (int i = 0; i < request.Images.Count; i++)
            {
                ExcursionsServiceAddImageReq image = request.Images[i];

                ExcursionImageDTO mappedImage = _mapper.Map<ExcursionImageDTO>(image);
                mappedImage.ExcursionId = excursion.Id;
                mappedImage.Order = i + 1;

                _excursionsDbContext.ExcursionsImages.Add(mappedImage);
                images.Add(mappedImage);
            }

            _excursionsDbContext.SaveChanges();

            for (int i = 0; i < images.Count; i++)
            {
                ExcursionImageDTO image = images[i];
                byte[] imageBytes = Convert.FromBase64String(request.Images[i].Base64);
                await _imagesService.ProcessImageAsync(imageBytes, $"Excursions", $"{image.Id}");
            }
        }

        public async Task Edit(ExcursionsServiceEditReq request)
        {
            ExcursionDTO excursion = _mapper.Map<ExcursionDTO>(request);
            _excursionsDbContext.Excursions.Update(excursion);
            await _excursionsDbContext.SaveChangesAsync();

            await _DeleteMarkedImages(request);
            await _excursionsDbContext.SaveChangesAsync();

            await _AddNewImages(request, excursion.Id);

            _UpdateImagesOrder(request);
            await _excursionsDbContext.SaveChangesAsync();
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

        private async Task _DeleteMarkedImages(ExcursionsServiceEditReq request)
        {
            List<int> idsToDelete = request.Images.Where(x => x.Deleted).Select(x => x.Id).ToList();
            List<ExcursionImageDTO> imagesToDelete = _excursionsDbContext.ExcursionsImages.Where(x => idsToDelete.Contains(x.Id))?.ToList() ?? new();

            if (imagesToDelete.Any())
            {
                _excursionsDbContext.ExcursionsImages.RemoveRange(imagesToDelete);

                foreach (ExcursionImageDTO image in imagesToDelete)
                    await _imagesService.DeleteImagesAsync("Excursions", image.Id);
            }
        }

        private async Task _AddNewImages(ExcursionsServiceEditReq request, int excursionId)
        {
            request.Images = request.Images.Where(x => x.Id == 0 && !x.Deleted).ToList();
            List<ExcursionImageDTO> images = new();

            foreach (var imageReq in request.Images)
            {
                ExcursionImageDTO mappedImage = _mapper.Map<ExcursionImageDTO>(imageReq);
                mappedImage.ExcursionId = excursionId;
                _excursionsDbContext.ExcursionsImages.Add(mappedImage);
                images.Add(mappedImage);
            }

            await _excursionsDbContext.SaveChangesAsync();

            for(var i = 0; i < images.Count; i++)
            {
                ExcursionImageDTO image = images[i];
                byte[] imageBytes = Convert.FromBase64String(request.Images[i].Base64);
                await _imagesService.ProcessImageAsync(imageBytes, $"Excursions", $"{image.Id}");
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