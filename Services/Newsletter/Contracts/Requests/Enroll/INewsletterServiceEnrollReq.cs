namespace JDPodrozeAPI.Services.Newsletter.Contracts.Requests
{
    public interface INewsletterServiceEnrollReq
    {
        public string Email { get; set; }
        public string Name { get; set; }
    }
}