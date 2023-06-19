using JDPodrozeAPI.Core.Contexts.Users;
using JDPodrozeAPI.Core.DTOs;
using Microsoft.EntityFrameworkCore;

namespace JDPodrozeAPI.Core.Contexts.Excursions
{
    public class ExcursionsDbContext : DbContext, IExcursionsDbContext
    {
        public ExcursionsDbContext(DbContextOptions<ExcursionsDbContext> options) : base(options)
        {

        }

        public DbSet<ExcursionDTO> Excursions { get; set; }
    }
}