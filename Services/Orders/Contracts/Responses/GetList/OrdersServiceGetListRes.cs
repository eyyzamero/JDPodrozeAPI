namespace JDPodrozeAPI.Services.Orders.Contracts.Responses
{
    public class OrdersServiceGetListRes : IOrdersServiceGetListRes
    {
        public List<OrdersServiceGetListItemRes> Items { get; set; }
    }
}