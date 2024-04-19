using AutoMapper;
using JDPodrozeAPI.Controllers.Orders.Contracts;
using JDPodrozeAPI.Core.Contexts.Excursions;
using JDPodrozeAPI.Core.DTOs;
using JDPodrozeAPI.Core.DTOs.Excursions;
using JDPodrozeAPI.Core.Enums;
using JDPodrozeAPI.Services.Orders;
using JDPodrozeAPI.Services.Orders.Contracts.Responses;
using JDPodrozeAPI.Services.Orders.Enums;
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

        public async Task<IOrdersServiceGetListRes> GetList(IOrdersGetListReq request)
        {
            IQueryable<ExcursionDTO> listQuery = _excursionsDbContext.Excursions
                .Include(x => x.Orders)
                .ThenInclude(x => x.Participants)
                .Where(x => x.Orders.Any());

            switch(request.Active)
            {
                case OrdersListFilterActiveType.ACTIVE:
                    listQuery = listQuery.Where(x => x.Active);
                    break;
                case OrdersListFilterActiveType.INACTIVE:
                    listQuery = listQuery.Where(x => !x.Active);
                    break;
                case OrdersListFilterActiveType.ARCHIVED:
                    listQuery = listQuery.Where(x => !x.Active || (x.DateFrom == null || x.DateFrom < DateTime.Now));
                    break;
            }

            List<ExcursionDTO> list = await listQuery
                .OrderBy(x => x.DateFrom)
                .ToListAsync();

            IOrdersServiceGetListRes serviceRes = _mapper.Map<OrdersServiceGetListRes>(list);
            return serviceRes;
        }

        public async Task<IOrdersGetExcursionOrdersWithDetailsRes> GetExcursionOrdersWithDetails(int excursionId)
        {
            ExcursionDTO excursion = _excursionsDbContext.Excursions
                .Include(x => x.Orders)
                .ThenInclude(x => x.Participants)
                .Single(x => x.Id == excursionId);

            excursion.Orders = excursion.Orders
                .OrderByDescending(x => x.BookerId)
                .ToList();

            excursion.Orders.ForEach(order => 
                order.Participants = order.Participants
                    .OrderBy(x => x.BookerId != null)
                    .ThenBy(x => $"{x.Name} {x.Surname}")
                    .ToList());

            IOrdersGetExcursionOrdersWithDetailsRes response = _mapper.Map<OrdersGetExcursionOrdersWithDetailsRes>(excursion);
            return response;
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