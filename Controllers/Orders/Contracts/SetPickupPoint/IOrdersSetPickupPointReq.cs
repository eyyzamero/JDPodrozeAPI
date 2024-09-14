namespace JDPodrozeAPI.Controllers.Orders.Contracts
{
    public interface IOrdersSetPickupPointReq
    {
        public Guid OrderId { get; }

        public Guid PickupPointId { get; }
    }
}