namespace JDPodrozeAPI.Services.Excursions.Contracts.Requests
{
    public interface IExcursionsServiceAddImageReq
    {
        public int ExcursionId { get; set; }
        public string Type { get; set; }
        public string Base64 { get; set; }
        public string Name { get; set; }
    }
}