using JDPodrozeAPI.Core.DTOs.Users;
using Microsoft.EntityFrameworkCore;

namespace JDPodrozeAPI.Core.Contexts.Users
{
    public class UsersDbContext : DbContext, IUsersDbContext
    {
        public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
        {

        }

        public DbSet<UserDTO> Users { get; set; }
    }
}