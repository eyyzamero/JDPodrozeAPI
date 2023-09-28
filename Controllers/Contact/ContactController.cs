using AutoMapper;
using JDPodrozeAPI.Controllers.Contact.Contracts.Requests;
using JDPodrozeAPI.Services;
using JDPodrozeAPI.Services.Contact.Contracts.Requests;
using Microsoft.AspNetCore.Mvc;

namespace JDPodrozeAPI.Controllers.Contact
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class ContactController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IContactService _contactService;

        public ContactController(IMapper mapper, IContactService contactService)
        {
            _mapper = mapper;
            _contactService = contactService;
        }

        [HttpPost("")]
        public IActionResult Contact(ContactReq request)
        {
            IContactServiceReq serviceRequest = _mapper.Map<ContactServiceReq>(request);
            _contactService.SaveMessage(serviceRequest);
            return Ok();
        }
    }
}
