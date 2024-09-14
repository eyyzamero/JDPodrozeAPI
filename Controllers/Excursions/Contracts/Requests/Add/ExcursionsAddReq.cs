namespace JDPodrozeAPI.Controllers.Excursions.Contracts.Requests
{
    public class ExcursionsAddReq : IExcursionsAddReq
    {
        public string Title { get; init; }

        public string ShortDescription { get; init; }

        public string Description { get; init; }

        public bool Active { get; init; }

        public bool InCarousel { get; init; }

        public decimal Price { get; init; }

        public bool Discount { get; init; }

        public decimal DiscountPrice { get; init; }

        public int Seats { get; init; }

        public string? DateFrom { get; init; }

        public string? DateTo { get; init; }

        public bool IsTemplate { get; init; }

        public List<ExcursionsAddImageReq> Images { get; init; }

        public List<ExcursionsAddPickupPointReq> PickupPoints { get; init; }
    }
}