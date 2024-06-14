namespace JDPodrozeAPI.Services.Excursions.Contracts.Responses
{
    public class ExcursionsServiceGetItemPickupPointRes : IExcursionsServiceGetItemPickupPointRes
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}