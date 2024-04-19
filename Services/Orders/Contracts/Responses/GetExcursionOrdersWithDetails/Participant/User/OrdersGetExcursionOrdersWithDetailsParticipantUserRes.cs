namespace JDPodrozeAPI.Services.Orders.Contracts.Responses
{
    public record OrdersGetExcursionOrdersWithDetailsParticipantUserRes : IOrdersGetExcursionOrdersWithDetailsParticipantUserRes
    {
        public int Id { get; init; }
        public string Login { get; init; }
    }
}