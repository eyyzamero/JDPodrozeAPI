using JDPodrozeAPI.Core.DTOs;
using Microsoft.EntityFrameworkCore;

namespace JDPodrozeAPI.Core.Contexts
{
    public interface IVisitsDbContext
    {
        public DbSet<VisitDTO> Visits { get; set; }
    }
}