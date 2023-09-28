using AutoMapper;
using JDPodrozeAPI.Core.DTOs.Excursions;
using JDPodrozeAPI.Core.DTOs;
using JDPodrozeAPI.Services.Orders.Contracts.Responses;

namespace JDPodrozeAPI.Services.Orders.Profiles
{
    public class OrdersServiceResponsesProfile : Profile
    {
        public OrdersServiceResponsesProfile()
        {
            CreateMap<ExcursionDTO, OrdersServiceGetListItemRes>()
                .ForMember(dest => dest.Orders, opt => opt.MapFrom(src => src.Orders));

            CreateMap<ExcursionOrderDTO, OrdersServiceGetListOrderRes>()
                .ForMember(dest => dest.Participants, opt => opt.MapFrom(src => src.Participants));

            CreateMap<ExcursionParticipantDTO, OrdersServiceGetListOrderParticipantRes>();
        }
    }
}