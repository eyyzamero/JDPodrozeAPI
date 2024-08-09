using JDPodrozeAPI.Core.DTOs.Newsletter;

namespace JDPodrozeAPI.Core.Repositories
{
    public interface INewsletterRepository
    {
        public Task<int> AddNewsletterAsync(NewsletterDTO newsletter);
    }
}