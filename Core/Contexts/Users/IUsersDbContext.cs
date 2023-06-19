using JDPodrozeAPI.Core.DTOs.Users;
using Microsoft.EntityFrameworkCore;

namespace JDPodrozeAPI.Core.Contexts.Users
{
    public interface IUsersDbContext
    {
        DbSet<UserDTO> Users { get; set; }
    }
}
