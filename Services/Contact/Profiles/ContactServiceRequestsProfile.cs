using AutoMapper;
using JDPodrozeAPI.Core.DTOs;
using JDPodrozeAPI.Services.Contact.Contracts.Requests;

namespace JDPodrozeAPI.Services.Contact.Profiles
{
    public class ContactServiceRequestsProfile : Profile
    {
        public ContactServiceRequestsProfile()
        {
            CreateMap<ContactServiceReq, ContactDTO>();
        }
    }
}