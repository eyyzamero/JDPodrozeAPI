namespace JDPodrozeAPI.Services.Orders.Contracts.Responses
{
    public record OrdersGetExcursionOrderWithDetailsExcursionPickupPointRes : IOrdersGetExcursionOrderWithDetailsExcursionPickupPointRes
    {
        public Guid Id { get; init; }

        public string Name { get; init; }
    }
}