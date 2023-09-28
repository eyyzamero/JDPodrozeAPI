using JDPodrozeAPI.Core.DTOs;
using Microsoft.EntityFrameworkCore;

namespace JDPodrozeAPI.Core.Contexts
{
    public interface IContactDbContext
    {
        public DbSet<ContactDTO> Messages { get; set; }
    }
}