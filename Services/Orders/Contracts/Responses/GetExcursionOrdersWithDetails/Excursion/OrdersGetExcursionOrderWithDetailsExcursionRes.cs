namespace JDPodrozeAPI.Services.Orders.Contracts.Responses
{
    public record OrdersGetExcursionOrderWithDetailsExcursionRes : IOrdersGetExcursionOrderWithDetailsExcursionRes
    {
        public int Id { get; init; }
        public string Title { get; init; }
        public bool Active { get; init; }
        public DateTime? DateFrom { get; init; }
        public DateTime? DateTo { get; init; }
        public decimal PriceGross { get; init; }
        public decimal DiscountPriceGross { get; init; }
        public int Seats { get; init; }
        public int AvailableSeats { get; init; }
    }
}