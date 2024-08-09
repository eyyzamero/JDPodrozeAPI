namespace JDPodrozeAPI.Core.Models.Configuration.Cryptography
{
    public record ApplicationConfigurationCryptography
    {
        public string Salt { get; init; }
    }
}