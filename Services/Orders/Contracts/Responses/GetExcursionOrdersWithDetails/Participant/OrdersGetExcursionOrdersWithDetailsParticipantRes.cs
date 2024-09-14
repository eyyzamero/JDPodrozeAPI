namespace JDPodrozeAPI.Services.Orders.Contracts.Responses
{
    public record OrdersGetExcursionOrdersWithDetailsParticipantRes : IOrdersGetExcursionOrdersWithDetailsParticipantRes
    {
        public int Id { get; init; }

        public int? BookerId { get; init; }

        public string Name { get; init; }

        public string Surname { get; init; }

        public bool Discount { get; init; }

        public string? Email { get; init; }

        public string? TelephoneNumber { get; init; }

        public DateTime BirthDate { get; init; }

        public OrdersGetExcursionOrdersWithDetailsParticipantUserRes? User { get; init; }
    }
}