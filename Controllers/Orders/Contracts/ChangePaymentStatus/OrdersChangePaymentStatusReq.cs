namespace JDPodrozeAPI.Controllers.Orders.Contracts
{
    public record OrdersChangePaymentStatusReq : IOrdersChangePaymentStatusReq
    {
        public char Status { get; init; }
    }
}