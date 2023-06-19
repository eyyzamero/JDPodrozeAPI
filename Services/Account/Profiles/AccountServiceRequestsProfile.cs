using AutoMapper;
using JDPodrozeAPI.Core.DTOs.Users;
using JDPodrozeAPI.Services.Account.Contracts.Requests;

namespace JDPodrozeAPI.Services.Account.Profiles
{
    public class AccountServiceRequestsProfile : Profile
    {
        public AccountServiceRequestsProfile()
        {
            CreateMap<AccountServiceRegisterReq, UserDTO>();
        }
    }
}