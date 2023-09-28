namespace JDPodrozeAPI.Services.Excursions.Contracts.Responses
{
    public interface IExcursionsServiceGetImageRes
    {
        byte[] RawImageBytes { get; set; }
        string Type { get; set; }
        string Name { get; set; }
    }
}