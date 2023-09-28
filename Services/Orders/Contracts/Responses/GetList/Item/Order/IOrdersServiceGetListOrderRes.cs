namespace JDPodrozeAPI.Services.Orders.Contracts.Responses
{
    public interface IOrdersServiceGetListOrderRes
    {
        public Guid OrderId { get; set; }
        public char PaymentMethod { get; set; }
        public char PaymentStatus { get; set; }
        public int BookerId { get; set; }
        public decimal Price { get; set; }
        public List<OrdersServiceGetListOrderParticipantRes> Participants { get; set; }
    }
}