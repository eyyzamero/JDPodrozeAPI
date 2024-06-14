namespace JDPodrozeAPI.Services.Excursions.Contracts.Responses
{
    public interface IExcursionsServiceGetItemPickupPointRes
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}