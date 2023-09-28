using JDPodrozeAPI.Core.DTOs;
using JDPodrozeAPI.Core.DTOs.Excursions;
using Microsoft.EntityFrameworkCore;

namespace JDPodrozeAPI.Core.Contexts.Excursions
{
    public class ExcursionsDbContext : DbContext, IExcursionsDbContext
    {
        public ExcursionsDbContext(DbContextOptions<ExcursionsDbContext> options) : base(options)
        {

        }

        public DbSet<ExcursionDTO> Excursions { get; set; }
        public DbSet<ExcursionImageDTO> ExcursionsImages { get; set; }
        public DbSet<ExcursionOrderDTO> ExcursionsOrders { get; set; }
        public DbSet<ExcursionParticipantDTO> ExcursionsParticipants { get; set; }
    }
}