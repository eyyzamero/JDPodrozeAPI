using AutoMapper;
using JDPodrozeAPI.Core.Contexts;
using JDPodrozeAPI.Core.DTOs;
using JDPodrozeAPI.Services.Contact.Contracts.Requests;

namespace JDPodrozeAPI.Services
{
    public class ContactService : IContactService
    {
        private readonly IMapper _mapper;
        private readonly ContactDbContext _contactDbContext;

        public ContactService(IMapper mapper, ContactDbContext contactDbContext)
        {
            _mapper = mapper;
            _contactDbContext = contactDbContext;
        }

        public void SaveMessage(IContactServiceReq request)
        {
            ContactDTO message = _mapper.Map<ContactDTO>(request);
            _contactDbContext.Messages.Add(message);
            _contactDbContext.SaveChanges();
        }
    }
}