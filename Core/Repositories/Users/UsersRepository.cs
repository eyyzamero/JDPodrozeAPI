using JDPodrozeAPI.Core.Contexts.Users;
using JDPodrozeAPI.Core.DTOs;
using Microsoft.EntityFrameworkCore;

namespace JDPodrozeAPI.Core.Repositories
{
    public class UsersRepository : BaseRepository<UsersDbContext>, IUsersRepository
    {
        public UsersRepository(UsersDbContext context) : base(context)
        {

        }

        public async Task<UserDTO?> GetUserByLoginAsync(string login)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.Login == login);
        }

        public async Task AddUserAsync(UserDTO user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<bool> IsLoginAvailable(string login)
        {
            return !(await _context.Users.AnyAsync(x => x.Login.ToLower() == login.Trim().ToLower()));
        } 
    }
}