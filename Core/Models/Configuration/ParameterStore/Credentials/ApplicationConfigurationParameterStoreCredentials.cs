namespace JDPodrozeAPI.Core.Models.Configuration.ParameterStore.Credentials
{
    public record ApplicationConfigurationParameterStoreCredentials
    {
        public string AccessKey { get; init; }

        public string SecretKey { get; init; }
    }
}