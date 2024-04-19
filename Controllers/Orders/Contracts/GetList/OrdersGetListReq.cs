using JDPodrozeAPI.Services.Orders.Enums;

namespace JDPodrozeAPI.Controllers.Orders.Contracts
{
    public class OrdersGetListReq : IOrdersGetListReq
    {
        public OrdersListFilterActiveType Active { get; set; }
    }
}