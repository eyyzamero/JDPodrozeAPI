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

            CreateMap<ExcursionImageDTO, ExcursionsServiceGetImageRes>()
                .ForMember(dest => dest.RawImageBytes, opt => opt.MapFrom(src => src.ImageData));

            CreateMap<ExcursionImageDTO, ExcursionsServiceGetListItemImageRes>();

            CreateMap<ExcursionDTO, ExcursionsServiceGetListItemRes>()
                .ForMember(dest => dest.DiscountPrice, opt => opt.MapFrom(src => src.DiscountPriceGross));

            CreateMap<List<ExcursionDTO>, ExcursionsServiceGetListRes>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src));

            CreateMap<ExcursionImageDTO, ExcursionsServiceGetItemImageRes>()
                .ForMember(dest => dest.Base64, opt => opt.MapFrom(src => Convert.ToBase64String(src.ImageData)));

            CreateMap<ExcursionDTO, ExcursionsServiceGetItemRes>()
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.PriceGross))
                .ForMember(dest => dest.DiscountPrice, opt => opt.MapFrom(src => src.DiscountPriceGross));
        }
    }
}