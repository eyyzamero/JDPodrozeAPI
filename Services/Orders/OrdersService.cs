using AutoMapper;
using JDPodrozeAPI.Controllers.Orders.Contracts;
using JDPodrozeAPI.Core.DTOs;
using JDPodrozeAPI.Core.DTOs.Excursions;
using JDPodrozeAPI.Core.Enums;
using JDPodrozeAPI.Core.Repositories;
using JDPodrozeAPI.Services.Orders;
using JDPodrozeAPI.Services.Orders.Contracts.Responses;

namespace JDPodrozeAPI.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IMapper _mapper;
        private readonly IOrdersRepository _ordersRepository;
        private readonly IEmailsService _emailsService;

        public OrdersService(IMapper mapper, IOrdersRepository ordersRepository, IEmailsService emailsService)
        {
            _mapper = mapper;
            _ordersRepository = ordersRepository;
            _emailsService = emailsService;
        }

        public async Task<IOrdersServiceGetListRes> GetList(IOrdersGetListReq request)
        {
            IList<ExcursionDTO> list = await _ordersRepository.GetList(request.Active);
            IOrdersServiceGetListRes serviceRes = _mapper.Map<IOrdersServiceGetListRes>(list);
            return serviceRes;
        }

        public async Task<IOrdersGetExcursionOrdersWithDetailsRes> GetExcursionOrdersWithDetails(int excursionId)
        {
            ExcursionDTO excursion = await _ordersRepository.GetExcursionWithOrders(excursionId);
            IOrdersGetExcursionOrdersWithDetailsRes response = _mapper.Map<OrdersGetExcursionOrdersWithDetailsRes>(excursion);
            return response;
        }

        public async Task ChangePaymentStatus(Guid orderId, PaymentStatus paymentStatus)
        {
            ExcursionOrderDTO order = await _ordersRepository.ChangePaymentStatus(orderId, paymentStatus);

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

        public async Task<int?> AddOrEditParticipant(IOrdersAddOrEditParticipantReq request)
        {
            ExcursionParticipantDTO participant = _mapper.Map<ExcursionParticipantDTO>(request);
            await _ordersRepository.AddOrEditParticipant(request.Id, request.OrderId, participant);
            return request.Id == null ? participant.Id : null;
        }

        public async Task DeleteParticipant(int participantId)
        {
            await _ordersRepository.DeleteParticipant(participantId);
        }

        public Task<bool> SetPickupPoint(IOrdersSetPickupPointReq request)
        {
            return _ordersRepository.SetPickupPoint(request.OrderId, request.PickupPointId);
        }
    }
}