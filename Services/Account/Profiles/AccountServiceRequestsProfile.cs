using AutoMapper;
using JDPodrozeAPI.Core.DTOs;
using JDPodrozeAPI.Services.Account.Contracts.Requests;

namespace JDPodrozeAPI.Services.Account.Profiles
{
    public class AccountServiceRequestsProfile : Profile
    {
        public AccountServiceRequestsProfile()
        {
            CreateMap<IAccountServiceRegisterReq, UserDTO>();
        }
    }
}