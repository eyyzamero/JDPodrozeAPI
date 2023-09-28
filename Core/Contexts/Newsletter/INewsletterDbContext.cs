using JDPodrozeAPI.Core.DTOs.Newsletter;
using Microsoft.EntityFrameworkCore;

namespace JDPodrozeAPI.Core.Contexts
{
    public interface INewsletterDbContext
    {
        public DbSet<NewsletterDTO> Newsletters { get; set; }
    }
}