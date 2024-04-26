namespace JDPodrozeAPI.Controllers.Orders.Contracts
{
    public record OrdersAddOrEditParticipantReq : IOrdersAddOrEditParticipantReq
    {
        public int? Id { get; init; }
        public int? BookerId { get; init; }
        public Guid OrderId { get; init; }
        public string Name { get; init; }
        public string Surname { get; init; }
        public string? Email { get; init; }
        public string? TelephoneNumber { get; init; }
        public string BirthDate { get; init; }
        public bool Discount { get; init; }
    }
}