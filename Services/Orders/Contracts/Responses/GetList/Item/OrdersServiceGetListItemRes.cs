namespace JDPodrozeAPI.Services.Orders.Contracts.Responses
{
    public class OrdersServiceGetListItemRes : IOrdersServiceGetListItemRes
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public decimal PriceGross { get; set; }
        public bool IsActive { get; set; }
        public int Seats { get; set; }
        public int AvailableSeats { get; set; }
    }
}