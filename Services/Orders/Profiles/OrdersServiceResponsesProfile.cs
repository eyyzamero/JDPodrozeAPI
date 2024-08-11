using AutoMapper;
using JDPodrozeAPI.Controllers.Orders.Contracts;
using JDPodrozeAPI.Core.DTOs;
using JDPodrozeAPI.Core.DTOs.Excursions;
using JDPodrozeAPI.Services.Orders.Contracts.Responses;

namespace JDPodrozeAPI.Services.Orders.Profiles
{
    public class OrdersServiceResponsesProfile : Profile
    {
        public OrdersServiceResponsesProfile()
        {
            // GetList
            CreateMap<ExcursionDTO, OrdersServiceGetListItemRes>()
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.Active))
                .AfterMap((src, dest) => dest.AvailableSeats = src.Seats - src.Orders.Sum(order => order.Participants.Count));

            CreateMap<ExcursionDTO, IOrdersServiceGetListItemRes>().AsProxy()
                .ConvertUsing((src, dest, context) => context.Mapper.Map<OrdersServiceGetListItemRes>(src));

            CreateMap<List<ExcursionDTO>, OrdersServiceGetListRes>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src));

            CreateMap<IList<ExcursionDTO>, IOrdersServiceGetListRes>().AsProxy()
                .ConvertUsing((src, dest, context) => context.Mapper.Map<OrdersServiceGetListRes>(src));

            // GetExcursionOrdersWithDetails
            CreateMap<ExcursionDTO, OrdersGetExcursionOrderWithDetailsExcursionRes>()
                .ForMember(dest => dest.AvailableSeats, opt => opt.MapFrom(src => src.Seats - src.Orders.Sum(order => order.Participants.Count)));

            CreateMap<ExcursionDTO, IOrdersGetExcursionOrderWithDetailsExcursionRes>().AsProxy()
                .ConvertUsing((src, dest, context) => context.Mapper.Map<OrdersGetExcursionOrderWithDetailsExcursionRes>(src));

            CreateMap<ExcursionOrderDTO, OrdersGetExcursionOrdersWithDetailsOrderRes>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.OrderId));

            CreateMap<ExcursionOrderDTO, IOrdersGetExcursionOrdersWithDetailsOrderRes>().AsProxy()
                .ConvertUsing((src, dest, context) => context.Mapper.Map<OrdersGetExcursionOrdersWithDetailsOrderRes>(src));

            CreateMap<UserDTO, OrdersGetExcursionOrdersWithDetailsParticipantUserRes>();

            CreateMap<UserDTO, IOrdersGetExcursionOrdersWithDetailsParticipantUserRes>().AsProxy()
                .ConvertUsing((src, dest, context) => context.Mapper.Map<OrdersGetExcursionOrdersWithDetailsParticipantUserRes>(src));

            CreateMap<ExcursionParticipantDTO, OrdersGetExcursionOrdersWithDetailsParticipantRes>();

            CreateMap<ExcursionParticipantDTO, IOrdersGetExcursionOrdersWithDetailsParticipantRes>().AsProxy()
                .ConvertUsing((src, dest, context) => context.Mapper.Map<OrdersGetExcursionOrdersWithDetailsParticipantRes>(src));

            CreateMap<ExcursionDTO, OrdersGetExcursionOrdersWithDetailsRes>()
                .ForMember(dest => dest.Excursion, opt => opt.MapFrom(src => src));

            CreateMap<ExcursionDTO, IOrdersGetExcursionOrdersWithDetailsRes>().AsProxy()
                .ConvertUsing((src, dest, context) => context.Mapper.Map<OrdersGetExcursionOrdersWithDetailsRes>(src));

            // AddOrEditParticipant

            CreateMap<IOrdersAddOrEditParticipantReq, ExcursionParticipantDTO>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.BookerId == null ? src.Email : null))
                .ForMember(dest => dest.TelephoneNumber, opt => opt.MapFrom(src => src.BookerId == null ? src.TelephoneNumber : null));
        }
    }
}