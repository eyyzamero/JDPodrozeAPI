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
            //GetListShort
            CreateMap<ExcursionDTO, ExcursionsServiceGetListShortItemRes>()
                .ForMember(dest => dest.DiscountPrice, opt => opt.MapFrom(src => src.DiscountPriceGross))
                .ForMember(x => x.ImageId, opt => opt.MapFrom(src => src.Images.OrderBy(x => x.Order).Select(x => x.Id).FirstOrDefault()));

            CreateMap<ExcursionDTO, IExcursionsServiceGetListShortItemRes>().AsProxy()
                .ConvertUsing((src, dest, context) => context.Mapper.Map<ExcursionsServiceGetListShortItemRes>(src));

            CreateMap<IList<ExcursionDTO>, ExcursionsServiceGetListShortRes>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src));

            CreateMap<IList<ExcursionDTO>, IExcursionsServiceGetListShortRes>().AsProxy()
                .ConvertUsing((src, dest, context) => context.Mapper.Map<ExcursionsServiceGetListShortRes>(src));

            CreateMap<ExcursionImageDTO, ExcursionsServiceGetImageRes>();

            CreateMap<ExcursionImageDTO, ExcursionsServiceGetListItemImageRes>();

            CreateMap<ExcursionDTO, ExcursionsServiceGetListItemRes>()
                .ForMember(dest => dest.DiscountPrice, opt => opt.MapFrom(src => src.DiscountPriceGross))
                .AfterMap((src, dest) => dest.AvailableSeats = src.Seats - src.Orders.Sum(order => order.Participants.Count));

            CreateMap<List<ExcursionDTO>, ExcursionsServiceGetListRes>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src));

            CreateMap<ExcursionImageDTO, ExcursionsServiceGetItemImageRes>();
            CreateMap<ExcursionPickupPointDTO, ExcursionsServiceGetItemPickupPointRes>();

            CreateMap<ExcursionDTO, ExcursionsServiceGetItemRes>()
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.PriceGross))
                .ForMember(dest => dest.DiscountPrice, opt => opt.MapFrom(src => src.DiscountPriceGross));

            CreateMap<ExcursionDTO, IExcursionsServiceGetItemRes>().AsProxy()
                .ConvertUsing((src, dest, context) => context.Mapper.Map<ExcursionsServiceGetItemRes>(src));
        }
    }
}