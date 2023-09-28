using AutoMapper;
using JDPodrozeAPI.Core.DTOs;
using JDPodrozeAPI.Core.DTOs.Excursions;
using JDPodrozeAPI.Core.Enums;
using JDPodrozeAPI.Services.Excursions.Contracts.Requests;

namespace JDPodrozeAPI.Services.Excursions.Profiles
{
    public class ExcursionsServiceRequestsProfile : Profile
    {
        public ExcursionsServiceRequestsProfile()
        {
            CreateMap<ExcursionsServiceAddImageReq, ExcursionImageDTO>()
                .ForMember(dest => dest.ImageData, opt => opt.MapFrom(src => Convert.FromBase64String(src.Base64)));

            CreateMap<ExcursionsServiceAddReq, ExcursionDTO>()
                .ForMember(dest => dest.PriceGross, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.DiscountPriceGross, opt => opt.MapFrom(src => src.DiscountPrice))
                .ForMember(dest => dest.PriceNet, opt => opt.MapFrom(src => 0))
                .ForMember(dest => dest.Images, opt => opt.Ignore());

            CreateMap<ExcursionsServiceEditImageReq, ExcursionImageDTO>()
                .ForMember(dest => dest.ImageData, opt => opt.MapFrom(src => Convert.FromBase64String(src.Base64)));

            CreateMap<ExcursionsServiceEditReq, ExcursionDTO>()
                .ForMember(dest => dest.PriceGross, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.DiscountPriceGross, opt => opt.MapFrom(src => src.DiscountPrice))
                .ForMember(dest => dest.PriceNet, opt => opt.MapFrom(src => 0))
                .ForMember(dest => dest.Images, opt => opt.Ignore());

            CreateMap<ExcursionsServiceEnrollPersonReq, ExcursionParticipantDTO>();

            CreateMap<ExcursionsServiceEnrollReq, ExcursionOrderDTO>()
                .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.PaymentMethod, opt => opt.MapFrom(src => (char) src.PaymentMethod))
                .ForMember(dest => dest.PaymentStatus, opt => opt.MapFrom(src => (char) PaymentStatus.NOT_PAID))
                .ForMember(dest => dest.Excursion, opt => opt.Ignore())
                .ForMember(dest => dest.Participants, opt => opt.Ignore());
                //.ForMember(dest => dest.Booker, opt => opt.Ignore());
        }
    }
}