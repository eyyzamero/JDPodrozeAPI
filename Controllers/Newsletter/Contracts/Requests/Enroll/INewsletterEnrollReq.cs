namespace JDPodrozeAPI.Controllers.Newsletter.Contracts.Requests
{
    public interface INewsletterEnrollReq
    {
        public string Email { get; set; }
        public string Name { get; set; }
    }
}