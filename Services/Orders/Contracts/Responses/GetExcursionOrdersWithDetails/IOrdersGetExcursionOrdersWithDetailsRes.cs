namespace JDPodrozeAPI.Services.Orders.Contracts.Responses
{
    public interface IOrdersGetExcursionOrdersWithDetailsRes
    {
        public OrdersGetExcursionOrderWithDetailsExcursionRes Excursion { get; }

        public List<OrdersGetExcursionOrdersWithDetailsOrderRes> Orders { get; }
    }
}