using JDPodrozeAPI.Controllers.Orders.Contracts;
using JDPodrozeAPI.Core.DTOs;
using JDPodrozeAPI.Core.Enums;
using JDPodrozeAPI.Services.Orders.Contracts.Responses;

namespace JDPodrozeAPI.Services
{
    public interface IOrdersService
    {
        public Task<IOrdersServiceGetListRes> GetList(IOrdersGetListReq request);
        public Task<IOrdersGetExcursionOrdersWithDetailsRes> GetExcursionOrdersWithDetails(int excursionId);
        public void ChangePaymentStatus(Guid orderId, PaymentStatus paymentStatus);
    }
}