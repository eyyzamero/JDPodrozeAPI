namespace JDPodrozeAPI.Services.Excursions.Contracts.Requests
{
    public interface IExcursionsServiceEditReq
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public bool InCarousel { get; set; }
        public decimal Price { get; set; }
        public bool Discount { get; set; }
        public decimal DiscountPrice { get; set; }
        public int Seats { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public bool IsTemplate { get; set; }
        public List<ExcursionsServiceEditImageReq> Images { get; set; }
				public List<ExcursionsServiceEditPickupPointReq> PickupPoints { get; set; }
		}
}