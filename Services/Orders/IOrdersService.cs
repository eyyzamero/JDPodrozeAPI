using JDPodrozeAPI.Controllers.Orders.Contracts;
using JDPodrozeAPI.Core.Enums;
using JDPodrozeAPI.Services.Orders.Contracts.Responses;

namespace JDPodrozeAPI.Services
{
    public interface IOrdersService
    {
        public Task<IOrdersServiceGetListRes> GetList(IOrdersGetListReq request);

        public Task<IOrdersGetExcursionOrdersWithDetailsRes> GetExcursionOrdersWithDetails(int excursionId);

        public Task ChangePaymentStatus(Guid orderId, PaymentStatus paymentStatus);

        public Task<int?> AddOrEditParticipant(IOrdersAddOrEditParticipantReq request);

        public Task DeleteParticipant(int participantId);

        public Task<bool> SetPickupPoint(IOrdersSetPickupPointReq request);
    }
}