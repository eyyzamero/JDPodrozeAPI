using AutoMapper;
using JDPodrozeAPI.Core.Contexts.Excursions;
using JDPodrozeAPI.Core.DTOs;
using JDPodrozeAPI.Core.DTOs.Excursions;
using JDPodrozeAPI.Core.Enums;
using JDPodrozeAPI.Services.Orders;
using JDPodrozeAPI.Services.Orders.Contracts.Responses;
using Microsoft.EntityFrameworkCore;

namespace JDPodrozeAPI.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IMapper _mapper;
        private readonly ExcursionsDbContext _excursionsDbContext;
        private readonly IEmailsService _emailsService;

        public OrdersService(IMapper mapper, ExcursionsDbContext excursionsDbContext, IEmailsService emailsService)
        {
            _mapper = mapper;
            _excursionsDbContext = excursionsDbContext;
            _emailsService = emailsService;
        }

        public List<OrdersServiceGetListItemRes> GetList()
        {
            List<ExcursionDTO> list = _excursionsDbContext.Excursions
                .Include(x => x.Orders)
                .ThenInclude(x => x.Participants)
                .OrderBy(x => x.DateFrom)
                .Where(x => x.Orders.Any())
                .ToList();
            List<OrdersServiceGetListItemRes> serviceRes = _mapper.Map<List<OrdersServiceGetListItemRes>>(list);
            return serviceRes;
        }

        public void ChangePaymentStatus(Guid orderId, PaymentStatus paymentStatus)
        {
            ExcursionOrderDTO order = _excursionsDbContext.ExcursionsOrders.Include(x => x.Participants).Include(x => x.Excursion).Single(x => x.OrderId == orderId);
            order.PaymentStatus = (char) paymentStatus;
            _excursionsDbContext.ExcursionsOrders.Update(order);
            _excursionsDbContext.SaveChanges();

            if ((PaymentStatus) order.PaymentStatus == PaymentStatus.PAID)
            {
                ExcursionParticipantDTO booker = order.Participants.Single(x => x.Id == order.BookerId);
                _emailsService.SendEmail(
                    email: booker.Email!,
                    senderDetails: $"{booker.Name} {booker.Surname}",
                    subject: "Potwierdzenie otrzymania wpłaty",
                    body: OrdersEmailsTemplates.GetConfirmationOfReceivedPayment(order.Excursion.Title, order.Price),
                    includeLogo: true
                );
            }
        }
    }
}