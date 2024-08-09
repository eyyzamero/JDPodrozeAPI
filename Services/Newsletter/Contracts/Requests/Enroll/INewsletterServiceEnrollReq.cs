namespace JDPodrozeAPI.Services.Newsletter.Contracts.Requests
{
    public interface INewsletterServiceEnrollReq
    {
        public string Email { get; init; }
        public string Name { get; init; }
    }
}