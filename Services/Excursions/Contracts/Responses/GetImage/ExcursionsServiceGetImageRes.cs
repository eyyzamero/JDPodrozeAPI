namespace JDPodrozeAPI.Services.Excursions.Contracts.Responses
{
    public class ExcursionsServiceGetImageRes : IExcursionsServiceGetImageRes
    {
        public byte[] RawImageBytes { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
    }
}