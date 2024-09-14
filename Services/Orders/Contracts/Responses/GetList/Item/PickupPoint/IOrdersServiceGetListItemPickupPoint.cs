namespace JDPodrozeAPI.Services.Orders.Contracts.Responses
{
    public interface IOrdersServiceGetListItemPickupPointRes
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}