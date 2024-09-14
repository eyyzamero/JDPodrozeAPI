using AutoMapper;
using JDPodrozeAPI.Core.DTOs;
using JDPodrozeAPI.Services.Users.Contracts.Responses;

namespace JDPodrozeAPI.Services.Users.Profiles
{
    public class UsersServiceResponsesProfile : Profile
    {
        public UsersServiceResponsesProfile()
        {
            // GetList
            CreateMap<UserDTO, UsersGetListUserRes>();

            CreateMap<UserDTO, IUsersGetListUserRes>().AsProxy()
                .ConvertUsing((src, dest, context) => context.Mapper.Map<UsersGetListUserRes>(src));

            CreateMap<IEnumerable<UserDTO>, UsersGetListRes>()
                .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src));

            CreateMap<IEnumerable<UserDTO>, IUsersGetListRes>().AsProxy()
                .ConvertUsing((src, dest, context) => context.Mapper.Map<UsersGetListRes>(src));
        }
    }
}