namespace JDPodrozeAPI.Controllers.Excursions.Contracts.Responses
{
    public interface IExcursionsGetItemImageRes
    {
        public int Id { get; set; }
        public int ExcursionId { get; set; }
        public int Order { get; set; }
        public string Base64 { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}