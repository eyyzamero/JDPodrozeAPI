namespace JDPodrozeAPI.Services.Excursions.Contracts.Requests
{
    public class ExcursionsServiceEditImageReq : IExcursionsServiceEditImageReq
    {
        public int Id { get; set; }
        public int ExcursionId { get; set; }
        public int Order { get; set; }
        public string Type { get; set; }
        public string Base64 { get; set; }
        public string Name { get; set; }
        public bool Deleted { get; set; }
    }
}