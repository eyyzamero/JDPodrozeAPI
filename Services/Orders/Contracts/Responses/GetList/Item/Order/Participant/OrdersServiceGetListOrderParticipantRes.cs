namespace JDPodrozeAPI.Services.Orders.Contracts.Responses
{
    public class OrdersServiceGetListOrderParticipantRes : IOrdersServiceGetListOrderParticipantRes
    {
        public int Id { get; set; }
        public int? BookerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Email { get; set; }
        public string? TelephoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Discount { get; set; }
    }
}