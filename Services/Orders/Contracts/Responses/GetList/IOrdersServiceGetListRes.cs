namespace JDPodrozeAPI.Services.Orders.Contracts.Responses
{
    public interface IOrdersServiceGetListRes
    {
        public List<OrdersServiceGetListItemRes> Items { get; set; }
    }
}