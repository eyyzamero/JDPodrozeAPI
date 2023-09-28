using JDPodrozeAPI.Core.DTOs;
using Microsoft.EntityFrameworkCore;

namespace JDPodrozeAPI.Core.Contexts
{
    public class ContactDbContext : DbContext, IContactDbContext
    {
        public ContactDbContext(DbContextOptions<ContactDbContext> options) : base(options)
        {

        }

        public DbSet<ContactDTO> Messages { get; set; }
    }
}