using JDPodrozeAPI.Core.Models.Configuration.Authentication;
using JDPodrozeAPI.Core.Models.Configuration.ParameterStore;
using JDPodrozeAPI.Core.Models.Configuration.Database;
using JDPodrozeAPI.Core.Models.Configuration.Cryptography;
using JDPodrozeAPI.Core.Models.Configuration.SMTP;

namespace JDPodrozeAPI.Core.Models.Configuration
{
    public class ApplicationConfiguration
    {
        public ApplicationConfigurationParameterStore ParameterStore { get; init; }
        public ApplicationConfigurationAuthentication Authentication { get; init; }
        public ApplicationConfigurationDatabase Database { get; init; }
        public ApplicationConfigurationCryptography Cryptography { get; init; }
        public ApplicationConfigurationSMTP SMTP { get; init; }
    }
}