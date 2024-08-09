using AutoMapper;
using JDPodrozeAPI.Core.DTOs;
using JDPodrozeAPI.Services.Account.Contracts.Responses;

namespace JDPodrozeAPI.Services.Account.Profiles
{
    public class AccountServiceResponsesProfile : Profile
    {
        public AccountServiceResponsesProfile()
        {
            CreateMap<UserDTO, IAccountServiceRegisterRes>().AsProxy();
        }
    }
}