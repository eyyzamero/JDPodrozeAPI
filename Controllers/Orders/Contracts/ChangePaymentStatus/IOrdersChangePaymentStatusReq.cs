namespace JDPodrozeAPI.Controllers.Orders.Contracts
{
    public interface IOrdersChangePaymentStatusReq
    {
        public char Status { get; init; }
    }
}