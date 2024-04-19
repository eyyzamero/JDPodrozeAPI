namespace JDPodrozeAPI.Services.Orders.Contracts.Responses
{
    public record OrdersGetExcursionOrdersWithDetailsRes : IOrdersGetExcursionOrdersWithDetailsRes
    {
        public OrdersGetExcursionOrderWithDetailsExcursionRes Excursion { get; init; }
        public List<OrdersGetExcursionOrdersWithDetailsOrderRes> Orders { get; init; }
    }
}