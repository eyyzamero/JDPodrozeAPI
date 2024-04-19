namespace JDPodrozeAPI.Services.Orders.Contracts.Responses
{
    public interface IOrdersGetExcursionOrderWithDetailsExcursionRes
    {
        public int Id { get; }
        public string Title { get; }
        public bool Active { get; }
        public DateTime? DateFrom { get; }
        public DateTime? DateTo { get; }
        public decimal PriceGross { get; }
        public decimal DiscountPriceGross { get; }
        public int Seats { get; }
        public int AvailableSeats { get; }
    }
}