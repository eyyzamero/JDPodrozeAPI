namespace JDPodrozeAPI.Services.Orders.Contracts.Responses
{
    public record OrdersServiceGetListItemPickupPointRes : IOrdersServiceGetListItemPickupPointRes
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}