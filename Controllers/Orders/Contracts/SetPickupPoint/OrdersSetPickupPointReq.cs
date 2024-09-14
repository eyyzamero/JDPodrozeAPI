namespace JDPodrozeAPI.Controllers.Orders.Contracts
{
    public class OrdersSetPickupPointReq : IOrdersSetPickupPointReq
    {
        public Guid OrderId { get; init; }

        public Guid PickupPointId { get; init; }
    }
}
