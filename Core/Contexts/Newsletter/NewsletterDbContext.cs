using JDPodrozeAPI.Core.DTOs.Newsletter;
using Microsoft.EntityFrameworkCore;

namespace JDPodrozeAPI.Core.Contexts
{
    public class NewsletterDbContext : DbContext, INewsletterDbContext
    {
        public NewsletterDbContext(DbContextOptions<NewsletterDbContext> options) : base(options)
        {

        }

        public DbSet<NewsletterDTO> Newsletters { get; set; }
    }
}