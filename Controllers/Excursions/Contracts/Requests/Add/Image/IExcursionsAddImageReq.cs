namespace JDPodrozeAPI.Controllers.Excursions.Contracts.Requests
{
    public interface IExcursionsAddImageReq
    {
        public string Type { get; set; }
        public string Base64 { get; set; }
        public string Name { get; set; }
    }
}