using AutoMapper;
using JDPodrozeAPI.Core.DTOs;
using JDPodrozeAPI.Core.DTOs.Excursions;
using JDPodrozeAPI.Services.Excursions.Contracts.Responses;

namespace JDPodrozeAPI.Services.Excursions.Profiles
{
    public class ExcursionsServiceResponsesProfile : Profile
    {
        public ExcursionsServiceResponsesProfile()
        {
            CreateMap<ExcursionDTO, ExcursionsServiceGetListShortItemRes>()
                .ForMember(dest => dest.DiscountPrice, opt => opt.MapFrom(src => src.DiscountPriceGross))
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
            
            CreateMap<List<ExcursionDTO>, ExcursionsServiceGetListShortRes>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src));

            CreateMap<ExcursionImageDTO, ExcursionsServiceGetImageRes>();

            CreateMap<ExcursionImageDTO, ExcursionsServiceGetListItemImageRes>();

            CreateMap<ExcursionDTO, ExcursionsServiceGetListItemRes>()
                .ForMember(dest => dest.DiscountPrice, opt => opt.MapFrom(src => src.DiscountPriceGross))
                .AfterMap((src, dest) => dest.AvailableSeats = src.Seats - src.Orders.Sum(order => order.Participants.Count));

            CreateMap<List<ExcursionDTO>, ExcursionsServiceGetListRes>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src));

            CreateMap<ExcursionImageDTO, ExcursionsServiceGetItemImageRes>();

            CreateMap<ExcursionDTO, ExcursionsServiceGetItemRes>()
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.PriceGross))
                .ForMember(dest => dest.DiscountPrice, opt => opt.MapFrom(src => src.DiscountPriceGross));
        }
    }
}