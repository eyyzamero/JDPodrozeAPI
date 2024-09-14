namespace JDPodrozeAPI.Services.Orders.Contracts.Responses
{
    public record OrdersGetExcursionOrdersWithDetailsOrderRes : IOrdersGetExcursionOrdersWithDetailsOrderRes
    {
        public Guid Id { get; init; }

        public char PaymentMethod { get; init; }

        public char PaymentStatus { get; init; }

        public int BookerId { get; init; }

        public decimal Price { get; init; }

        public Guid? PickupPointId { get; init; }

        public List<OrdersGetExcursionOrdersWithDetailsParticipantRes> Participants { get; init; }
    }
}