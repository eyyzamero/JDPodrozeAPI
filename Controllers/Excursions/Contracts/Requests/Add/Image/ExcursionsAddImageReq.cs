namespace JDPodrozeAPI.Controllers.Excursions.Contracts.Requests
{
    public record ExcursionsAddImageReq : IExcursionsAddImageReq
    {
        public string Type { get; init; }

        public string Base64 { get; init; }

        public string Name { get; init; }
    }
}