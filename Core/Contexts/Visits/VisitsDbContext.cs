using JDPodrozeAPI.Core.DTOs;
using Microsoft.EntityFrameworkCore;

namespace JDPodrozeAPI.Core.Contexts
{
    public class VisitsDbContext : DbContext, IVisitsDbContext
    {
        public VisitsDbContext(DbContextOptions<VisitsDbContext> options) : base(options)
        {

        }

        public DbSet<VisitDTO> Visits { get; set; }
    }
}