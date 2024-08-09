using AutoMapper;
using JDPodrozeAPI.Controllers.Excursions.Contracts.Requests;
using JDPodrozeAPI.Controllers.Excursions.Contracts.Responses;
using JDPodrozeAPI.Core.Enums;
using JDPodrozeAPI.Services.Excursions.Contracts.Requests;
using JDPodrozeAPI.Services.Excursions.Contracts.Responses;
using System.Globalization;

namespace JDPodrozeAPI.Controllers.Excursions.Profiles
{
    public class ExcursionsControllerProfile : Profile
    {
        public ExcursionsControllerProfile()
        {
            CreateMap<IExcursionsServiceGetListShortItemRes, ExcursionsGetListShortItemRes>();
            CreateMap<IExcursionsServiceGetListShortItemRes, IExcursionsGetListShortItemRes>().AsProxy()
                .ConvertUsing((src, dest, context) => context.Mapper.Map<ExcursionsGetListShortItemRes>(src));

            CreateMap<IExcursionsServiceGetListShortRes, ExcursionsGetListShortRes>();
            CreateMap<IExcursionsServiceGetListShortRes, IExcursionsGetListShortRes>().AsProxy()
                .ConvertUsing((src, dest, context) => context.Mapper.Map<ExcursionsGetListShortRes>(src));

            CreateMap<ExcursionsAddImageReq, ExcursionsServiceAddImageReq>();
            CreateMap<ExcursionsAddPickupPointReq, ExcursionsServiceAddPickupPointReq>();
            CreateMap<ExcursionsAddReq, ExcursionsServiceAddReq>()
                .ForMember(dest => dest.DateFrom, opt => opt.MapFrom(src => src.DateFrom == null ? (DateTime?)null : DateTime.ParseExact(src.DateFrom, "dd/MM/yyyy", CultureInfo.InvariantCulture)))
                .ForMember(dest => dest.DateTo, opt => opt.MapFrom(src => src.DateTo == null ? (DateTime?)null : DateTime.ParseExact(src.DateTo, "dd/MM/yyyy", CultureInfo.InvariantCulture)));
            
            CreateMap<ExcursionsEditImageReq, ExcursionsServiceEditImageReq>();
            CreateMap<ExcursionsEditPickupPointReq, ExcursionsServiceEditPickupPointReq>();
            CreateMap<ExcursionsEditReq, ExcursionsServiceEditReq>()
                .ForMember(dest => dest.DateFrom, opt => opt.MapFrom(src => src.DateFrom == null ? (DateTime?) null : DateTime.ParseExact(src.DateFrom, "dd/MM/yyyy", CultureInfo.InvariantCulture)))
                .ForMember(dest => dest.DateTo, opt => opt.MapFrom(src => src.DateTo == null ? (DateTime?) null : DateTime.ParseExact(src.DateTo, "dd/MM/yyyy", CultureInfo.InvariantCulture)));
            
            CreateMap<ExcursionsServiceGetItemImageRes, ExcursionsGetItemImageRes>();
            CreateMap<ExcursionsServiceGetItemPickupPointRes, ExcursionsGetItemPickupPointRes>();
            CreateMap<ExcursionsServiceGetItemRes, ExcursionsGetItemRes>();
            
            CreateMap<ExcursionEnrollPersonReq, ExcursionsServiceEnrollPersonReq>()
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => DateTime.ParseExact(src.BirthDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)));
            CreateMap<ExcursionsEnrollReq, ExcursionsServiceEnrollReq>()
                .ForMember(dest => dest.PaymentMethod, opt => opt.MapFrom(src => (PaymentMethod) src.PaymentMethod));
        }
    }
}