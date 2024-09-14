namespace JDPodrozeAPI.Controllers.Newsletter.Contracts.Requests
{
    public interface INewsletterEnrollReq
    {
        public string Email { get; init; }

        public string Name { get; init; }
    }
}