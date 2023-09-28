namespace JDPodrozeAPI.Controllers.Newsletter.Contracts.Requests
{
    public class NewsletterEnrollReq : INewsletterEnrollReq
    {
        public string Email { get; set; }
        public string Name { get; set; }
    }
}