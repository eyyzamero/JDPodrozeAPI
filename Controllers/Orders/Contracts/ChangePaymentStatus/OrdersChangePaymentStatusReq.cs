namespace JDPodrozeAPI.Controllers.Orders.Contracts
{
    public class OrdersChangePaymentStatusReq : IOrdersChangePaymentStatusReq
    {
        public char Status { get; set; }
    }
}