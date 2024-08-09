namespace JDPodrozeAPI.Core.Models.Configuration.Authentication
{
    public record ApplicationConfigurationAuthentication
    {
        public string SigningKey { get; init; }
        public string Issuer { get; init; }
        public string Audience { get; init; }
    }
}