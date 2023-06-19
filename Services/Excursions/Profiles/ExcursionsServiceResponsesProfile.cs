using AutoMapper;
using JDPodrozeAPI.Core.DTOs;
using JDPodrozeAPI.Services.Excursions.Contracts.Responses;

namespace JDPodrozeAPI.Services.Excursions.Profiles
{
    public class ExcursionsServiceResponsesProfile : Profile
    {
        public ExcursionsServiceResponsesProfile()
        {
            CreateMap<ExcursionDTO, ExcursionsServiceGetListShortItemRes>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
            
            CreateMap<List<ExcursionDTO>, ExcursionsServiceGetListShortRes>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src));
        }
    }
}