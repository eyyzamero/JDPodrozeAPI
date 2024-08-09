namespace JDPodrozeAPI.Services.Excursions.Contracts.Responses
{
    public record ExcursionsServiceGetListShortItemRes : IExcursionsServiceGetListShortItemRes
    {
        public int Id { get; init; }
        public string Title { get; init; }
        public string ShortDescription { get; init; }
        public decimal PriceGross { get; init; }
        public decimal PriceNet { get; init; }
        public bool Discount { get; init; }
        public decimal DiscountPrice { get; init; }
        public int Seats { get; init; }
        public DateTime? DateFrom { get; init; }
        public DateTime? DateTo { get; init; }
        public int? ImageId { get; init; }
        public bool InCarousel { get; init; }
    }
}