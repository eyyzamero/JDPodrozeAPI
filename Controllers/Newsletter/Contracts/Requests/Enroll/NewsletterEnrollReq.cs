namespace JDPodrozeAPI.Controllers.Newsletter.Contracts.Requests
{
    public record NewsletterEnrollReq : INewsletterEnrollReq
    {
        public string Email { get; init; }

        public string Name { get; init; }
    }
}