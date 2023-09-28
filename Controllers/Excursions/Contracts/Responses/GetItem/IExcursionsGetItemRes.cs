namespace JDPodrozeAPI.Controllers.Excursions.Contracts.Responses
{
    public interface IExcursionsGetItemRes
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public bool InCarousel { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public decimal Price { get; set; }
        public bool Discount { get; set; }
        public decimal DiscountPrice { get; set; }
        public List<ExcursionsGetItemImageRes> Images { get; set; }
    }
}