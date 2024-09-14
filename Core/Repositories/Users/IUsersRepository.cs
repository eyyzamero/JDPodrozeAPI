using JDPodrozeAPI.Core.DTOs;

namespace JDPodrozeAPI.Core.Repositories
{
    public interface IUsersRepository : IBaseRepository
    {
        public Task<UserDTO?> GetUserByLoginAsync(string login);

        public Task AddUserAsync(UserDTO user);

        public Task<bool> IsLoginAvailable(string login);

        public Task<List<UserDTO>> GetList();
    }
}