using AutoMapper;
using JDPodrozeAPI.Controllers.Newsletter.Contracts.Requests;
using JDPodrozeAPI.Services;
using JDPodrozeAPI.Services.Newsletter.Contracts.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
        [ProducesResponseType(typeof(void), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> Enroll(NewsletterEnrollReq request)
        {
            INewsletterServiceEnrollReq serviceReq = _mapper.Map<INewsletterServiceEnrollReq>(request);
            await _newsletterService.EnrollAsync(serviceReq);
            return Ok();
        }
    }
}