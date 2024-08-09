using JDPodrozeAPI.Core.Models.Configuration.ParameterStore.Credentials;

namespace JDPodrozeAPI.Core.Models.Configuration.ParameterStore
{
    public record ApplicationConfigurationParameterStore
    {
        public ApplicationConfigurationParameterStoreCredentials Credentials { get; init; }
    }
}