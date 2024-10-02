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

        public Task<UserDTO?> GetUserByIdAsync(int id)
        {
            return _context.Users.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddUserAsync(UserDTO user)
        {
            await _context.Users.AddAsync(user);
        }

        public void AddUser(UserDTO user)
        {
            _context.Users.Add(user);
        }

        public async Task UpdateUserAsync(UserDTO user)
        {
            UserDTO currentUser = await _context.Users
                .AsNoTracking()
                .SingleAsync(x => x.Id == user.Id);
            
            if (string.IsNullOrEmpty(user.Password))
                 user.Password = currentUser.Password;
            
            _context.Users.Update(user);
        }

        public async Task<bool> IsLoginAvailable(string login, string? currentLogin)
        {
            if (!string.IsNullOrWhiteSpace(currentLogin) && login.Trim().ToLower() == currentLogin.Trim().ToLower())
                return true;

            return !(await _context.Users.AnyAsync(x => x.Login.Trim().ToLower() == login.Trim().ToLower()));
        } 

        public Task<List<UserDTO>> GetList(string? searchText)
        {
            if (!string.IsNullOrEmpty(searchText))
            {
                return _context.Users
                    .FromSqlInterpolated($"EXEC SEL_USERS_SEARCH {searchText}")
                    .ToListAsync();
            }
            return _context.Users.ToListAsync();
        }

        public async Task DeleteAsync(int id)
        {
            UserDTO user = await _context.Users
                .AsNoTracking()
                .SingleAsync(x => x.Id == id);

            _context.Users.Remove(user);
        }
    }
}