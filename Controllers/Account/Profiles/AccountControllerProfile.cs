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
            CreateMap<AccountLoginReq, IAccountServiceLoginReq>().AsProxy()
                .ConvertUsing((src, dest, context) => context.Mapper.Map<AccountServiceLoginReq>(src));

            CreateMap<AccountRegisterReq, AccountServiceRegisterReq>();
            CreateMap<AccountRegisterReq, IAccountServiceRegisterReq>().AsProxy()
                .ConvertUsing((src, dest, context) => context.Mapper.Map<AccountServiceRegisterReq>(src));

            CreateMap<IAccountServiceRegisterRes, AccountRegisterRes>();
            CreateMap<IAccountServiceRegisterRes, IAccountRegisterRes>().AsProxy()
                .ConvertUsing((src, dest, context) => context.Mapper.Map<AccountRegisterRes>(src));
        }
    }
}