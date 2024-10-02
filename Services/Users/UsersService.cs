using AutoMapper;
using JDPodrozeAPI.Controllers.Users.Contracts.Requests;
using JDPodrozeAPI.Core.DTOs;
using JDPodrozeAPI.Core.Repositories;
using JDPodrozeAPI.Services.Users.Contracts.Responses;

namespace JDPodrozeAPI.Services
{
    public class UsersService : IUsersService
    {
        private readonly IMapper _mapper;
        private readonly IUsersRepository _usersRepository;

        public UsersService(IMapper mapper, IUsersRepository usersRepository)
        {
            _mapper = mapper;
            _usersRepository = usersRepository;
        }

        public async Task<IUsersGetListRes> GetList(IUsersGetListReq request)
        {
            IEnumerable<UserDTO> users = await _usersRepository.GetList(request.SearchText);
            IUsersGetListRes response = _mapper.Map<IUsersGetListRes>(users);
            return response;
        }
    }
}