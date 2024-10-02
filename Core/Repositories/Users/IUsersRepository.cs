using JDPodrozeAPI.Core.DTOs;

namespace JDPodrozeAPI.Core.Repositories
{
    public interface IUsersRepository : IBaseRepository
    {
        public Task<UserDTO?> GetUserByLoginAsync(string login);

        public Task<UserDTO?> GetUserByIdAsync(int id);

        public Task AddUserAsync(UserDTO user);

        public void AddUser(UserDTO user);

        public Task UpdateUserAsync(UserDTO user);

        public Task<bool> IsLoginAvailable(string login, string? currentLogin);

        public Task<List<UserDTO>> GetList(string? searchText);

        public Task DeleteAsync(int id);
    }
}