namespace JDPodrozeAPI.Controllers.Excursions.Contracts.Responses
{
    public interface IExcursionsGetItemPickupPointRes
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}