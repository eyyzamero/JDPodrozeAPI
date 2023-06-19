using AutoMapper;
using JDPodrozeAPI.Controllers.Excursions.Contracts.Responses;
using JDPodrozeAPI.Services.Excursions.Contracts.Responses;

namespace JDPodrozeAPI.Controllers.Excursions.Profiles
{
    public class ExcursionsControllerProfile : Profile
    {
        public ExcursionsControllerProfile()
        {
            CreateMap<ExcursionsServiceGetListShortItemRes, ExcursionsGetListShortItemRes>();
            CreateMap<ExcursionsServiceGetListShortRes, ExcursionsGetListShortRes>();
        }
    }
}