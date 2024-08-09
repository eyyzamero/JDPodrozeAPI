namespace JDPodrozeAPI.Core.Models.Configuration.SMTP
{
    public record ApplicationConfigurationSMTP
    {
        public string Email { get; init; }

        public string Password { get; init; }
    }
}