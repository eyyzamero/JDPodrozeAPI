using AutoMapper;
using JDPodrozeAPI.Core.DTOs;
using JDPodrozeAPI.Core.Repositories;
using JDPodrozeAPI.Services.Contact.Contracts.Requests;

namespace JDPodrozeAPI.Services
{
    public class ContactService : IContactService
    {
        private readonly IMapper _mapper;
        private readonly IContactRepository _contactRepository;

        public ContactService(IMapper mapper, IContactRepository contactRepository)
        {
            _mapper = mapper;
            _contactRepository = contactRepository;
        }

        public Task SaveMessageAsync(IContactServiceReq request)
        {
            ContactDTO message = _mapper.Map<ContactDTO>(request);
            return _contactRepository.AddMessage(message);
        }
    }
}