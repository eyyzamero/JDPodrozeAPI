using JDPodrozeAPI.Core.DTOs;
using Microsoft.EntityFrameworkCore;

namespace JDPodrozeAPI.Core.Contexts.Excursions
{
    public interface IExcursionsDbContext
    {
        DbSet<ExcursionDTO> Excursions { get; set; }
    }
}
