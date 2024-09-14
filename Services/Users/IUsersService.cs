using JDPodrozeAPI.Services.Users.Contracts.Responses;

namespace JDPodrozeAPI.Services
{
    public interface IUsersService
    {
        public Task<IUsersGetListRes> GetList();
    }
}