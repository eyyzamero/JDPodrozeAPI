namespace JDPodrozeAPI.Services.Newsletter.Contracts.Requests
{
    public record NewsletterServiceEnrollReq : INewsletterServiceEnrollReq
    {
        public string Email { get; init; }
        public string Name { get; init; }
    }
}