namespace JDPodrozeAPI.Services.Orders.Contracts.Responses
{
    public record OrdersServiceGetListItemRes : IOrdersServiceGetListItemRes
    {
        public int Id { get; init; }

        public string Title { get; init; }

        public DateTime? DateFrom { get; init; }

        public DateTime? DateTo { get; init; }

        public decimal PriceGross { get; init; }

        public bool IsActive { get; init; }

        public int Seats { get; init; }

        public int AvailableSeats { get; set; }

        public IList<IOrdersServiceGetListItemPickupPointRes> PickupPoints { get; init; }
    }
}