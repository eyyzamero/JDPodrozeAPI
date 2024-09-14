using JDPodrozeAPI.Services.Orders.Enums;

namespace JDPodrozeAPI.Controllers.Orders.Contracts
{
    public interface IOrdersGetListReq
    {
        public OrdersListFilterActiveType Active { get; init; }
    }
}