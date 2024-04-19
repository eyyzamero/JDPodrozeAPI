using AutoMapper;
using JDPodrozeAPI.Core.DTOs;
using JDPodrozeAPI.Core.DTOs.Excursions;
using JDPodrozeAPI.Core.DTOs.Users;
using JDPodrozeAPI.Services.Orders.Contracts.Responses;

namespace JDPodrozeAPI.Services.Orders.Profiles
{
    public class OrdersServiceResponsesProfile : Profile
    {
        public OrdersServiceResponsesProfile()
        {
            CreateMap<ExcursionDTO, OrdersServiceGetListItemRes>()
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.Active))
                .AfterMap((src, dest) => dest.AvailableSeats = src.Seats - src.Orders.Sum(order => order.Participants.Count));

            CreateMap<List<ExcursionDTO>, OrdersServiceGetListRes>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src));

            CreateMap<ExcursionDTO, OrdersGetExcursionOrderWithDetailsExcursionRes>()
                .ForMember(dest => dest.AvailableSeats, opt => opt.MapFrom(src => src.Seats - src.Orders.Sum(order => order.Participants.Count)));

            CreateMap<ExcursionOrderDTO, OrdersGetExcursionOrdersWithDetailsOrderRes>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.OrderId));

            CreateMap<UserDTO, OrdersGetExcursionOrdersWithDetailsParticipantUserRes>();

            CreateMap<ExcursionParticipantDTO, OrdersGetExcursionOrdersWithDetailsParticipantRes>();

            CreateMap<ExcursionDTO, OrdersGetExcursionOrdersWithDetailsRes>()
                .ForMember(dest => dest.Excursion, opt => opt.MapFrom(src => src));
        }
    }
}