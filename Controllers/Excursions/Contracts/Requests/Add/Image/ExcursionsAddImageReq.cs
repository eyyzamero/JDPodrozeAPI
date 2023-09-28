namespace JDPodrozeAPI.Controllers.Excursions.Contracts.Requests
{
    public class ExcursionsAddImageReq : IExcursionsAddImageReq
    {
        public string Type { get; set; }
        public string Base64 { get; set; }
        public string Name { get; set; }
    }
}