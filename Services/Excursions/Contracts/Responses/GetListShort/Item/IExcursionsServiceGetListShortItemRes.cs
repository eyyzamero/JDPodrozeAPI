namespace JDPodrozeAPI.Services.Excursions.Contracts.Responses
{
    public interface IExcursionsServiceGetListShortItemRes
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public decimal PriceGross { get; set; }
        public decimal PriceNet { get; set; }
        public bool Discount { get; set; }
        public decimal DiscountPrice { get; set; }
        public int Seats { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public int ImageId { get; set; }
        public bool InCarousel { get; set; }
    }
}