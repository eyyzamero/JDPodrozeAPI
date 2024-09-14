using AutoMapper;
using JDPodrozeAPI.Controllers.Contact.Contracts.Requests;
using JDPodrozeAPI.Services.Contact.Contracts.Requests;

namespace JDPodrozeAPI.Controllers.Contact.Profiles
{
    public class ContactControllerProfile : Profile
    {
        public ContactControllerProfile()
        {
            CreateMap<ContactReq, ContactServiceReq>();
            CreateMap<ContactReq, IContactServiceReq>().AsProxy()
                .ConvertUsing((src, dest, context) => context.Mapper.Map<ContactServiceReq>(src));
        }
    }
}