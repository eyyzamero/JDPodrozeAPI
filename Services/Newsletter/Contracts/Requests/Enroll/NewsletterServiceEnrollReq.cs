namespace JDPodrozeAPI.Services.Newsletter.Contracts.Requests
{
    public class NewsletterServiceEnrollReq : INewsletterServiceEnrollReq
    {
        public string Email { get; set; }
        public string Name { get; set; }
    }
}