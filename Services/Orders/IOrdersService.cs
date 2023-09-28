using JDPodrozeAPI.Core.DTOs;
using JDPodrozeAPI.Core.Enums;
using JDPodrozeAPI.Services.Orders.Contracts.Responses;

namespace JDPodrozeAPI.Services
{
    public interface IOrdersService
    {
        public List<OrdersServiceGetListItemRes> GetList();
        public void ChangePaymentStatus(Guid orderId, PaymentStatus paymentStatus);
    }
}