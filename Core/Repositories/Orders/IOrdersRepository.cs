using JDPodrozeAPI.Core.DTOs;
using JDPodrozeAPI.Core.DTOs.Excursions;
using JDPodrozeAPI.Core.Enums;
using JDPodrozeAPI.Services.Orders.Enums;

namespace JDPodrozeAPI.Core.Repositories
{
    public interface IOrdersRepository
    {
        public Task<List<ExcursionDTO>> GetList(OrdersListFilterActiveType active);

        public Task<ExcursionDTO> GetExcursionWithOrders(int excursionId);

        public Task<ExcursionOrderDTO> ChangePaymentStatus(Guid orderId, PaymentStatus status);

        public Task<Task<int>> AddOrEditParticipant(int? participantId, Guid orderId, ExcursionParticipantDTO participant);

        public Task<Task<int>> DeleteParticipant(int participantId);

        public Task<bool> SetPickupPoint(Guid orderId, Guid pickupPointId);
    }
}