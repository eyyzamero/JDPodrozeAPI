using JDPodrozeAPI.Controllers.Users.Contracts.Requests;
using JDPodrozeAPI.Services.Users.Contracts.Responses;

namespace JDPodrozeAPI.Services
{
    public interface IUsersService
    {
        public Task<IUsersGetListRes> GetList(IUsersGetListReq request);
    }
}