namespace JDPodrozeAPI.Core.Models.Configuration.Authentication
{
    public class ApplicationConfigurationAuthentication
    {
        public string SigningKey { get; init; }
        public string Issuer { get; init; }
        public string Audience { get; init; }
    }
}