namespace JDPodrozeAPI.Controllers.Excursions.Contracts.Requests
{
    public class ExcursionsEditReq : IExcursionsEditReq
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
        public string? DateFrom { get; set; }
        public string? DateTo { get; set; }
        public bool IsTemplate { get; set; }
        public List<ExcursionsEditImageReq> Images { get; set; }
				public List<ExcursionsEditPickupPointReq> PickupPoints { get; set; }
		}
}