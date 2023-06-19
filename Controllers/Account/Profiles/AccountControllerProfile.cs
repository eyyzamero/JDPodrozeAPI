using AutoMapper;
using JDPodrozeAPI.Controllers.Account.Contracts.Requests;
using JDPodrozeAPI.Controllers.Account.Contracts.Responses;
using JDPodrozeAPI.Services.Account.Contracts.Requests;
using JDPodrozeAPI.Services.Account.Contracts.Responses;

namespace JDPodrozeAPI.Controllers.Account.Profiles
{
    public class AccountControllerProfile : Profile
    {
        public AccountControllerProfile()
        {
            CreateMap<AccountLoginReq, AccountServiceLoginReq>();
            CreateMap<AccountRegisterReq, AccountServiceRegisterReq>();
            CreateMap<AccountServiceRegisterRes, AccountRegisterRes>();
        }
    }
}