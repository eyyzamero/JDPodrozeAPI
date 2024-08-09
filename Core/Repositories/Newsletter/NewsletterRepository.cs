using JDPodrozeAPI.Core.Contexts;
using JDPodrozeAPI.Core.DTOs.Newsletter;

namespace JDPodrozeAPI.Core.Repositories
{
    public class NewsletterRepository : BaseRepository<NewsletterDbContext>, INewsletterRepository
    {
        public NewsletterRepository(NewsletterDbContext context) : base(context)
        {
        
        }

        public Task<int> AddNewsletterAsync(NewsletterDTO newsletter)
        {
            _context.Newsletters.Add(newsletter);
            return _context.SaveChangesAsync();
        }
    }
}