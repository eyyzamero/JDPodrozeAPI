namespace JDPodrozeAPI.Services.Orders.Contracts.Responses
{
    public interface IOrdersGetExcursionOrdersWithDetailsOrderRes
    {
        public Guid Id { get; }
        public char PaymentMethod { get; }
        public char PaymentStatus { get; }
        public int BookerId { get; }
        public decimal Price { get; }
        public List<OrdersGetExcursionOrdersWithDetailsParticipantRes> Participants { get; }
    }
}