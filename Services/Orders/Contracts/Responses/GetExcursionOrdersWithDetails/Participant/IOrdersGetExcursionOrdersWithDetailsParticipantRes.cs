namespace JDPodrozeAPI.Services.Orders.Contracts.Responses
{
    public interface IOrdersGetExcursionOrdersWithDetailsParticipantRes
    {
        public int Id { get; }

        public int? BookerId { get; }

        public string Name { get; }

        public string Surname { get; }

        public bool Discount { get; }

        public string? Email { get; }

        public string? TelephoneNumber { get; }

        public DateTime BirthDate { get; }

        public OrdersGetExcursionOrdersWithDetailsParticipantUserRes? User { get; init; }
    }
}