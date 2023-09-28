using AutoMapper;
using JDPodrozeAPI.Controllers.Newsletter.Contracts.Requests;
using JDPodrozeAPI.Services;
using JDPodrozeAPI.Services.Newsletter.Contracts.Requests;
using Microsoft.AspNetCore.Mvc;

namespace JDPodrozeAPI.Controllers.Newsletter
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class NewsletterController : Controller
    {
        private readonly IMapper _mapper;
        private readonly INewsletterService _newsletterService;

        public NewsletterController(IMapper mapper, INewsletterService newsletterService)
        {
            _mapper = mapper;
            _newsletterService = newsletterService;
        }

        [HttpPost("Enroll")]
        public IActionResult Enroll(NewsletterEnrollReq request)
        {
            INewsletterServiceEnrollReq serviceReq = _mapper.Map<NewsletterServiceEnrollReq>(request);
            _newsletterService.Enroll(serviceReq);
            return Ok();
        }
    }
}
