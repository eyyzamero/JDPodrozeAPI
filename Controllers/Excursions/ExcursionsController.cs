using AutoMapper;
using JDPodrozeAPI.Controllers.Excursions.Contracts.Responses;
using JDPodrozeAPI.Services.Excursions;
using JDPodrozeAPI.Services.Excursions.Contracts.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace JDPodrozeAPI.Controllers.Excursions
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class ExcursionsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IExcursionsService _excursionsService;

        public ExcursionsController(IMapper mapper, IExcursionsService excursionsService) {
            _mapper = mapper;
            _excursionsService = excursionsService;
        }

        [HttpGet("GetListShort")]
        [ProducesResponseType(typeof(IExcursionsGetListShortRes), (int) HttpStatusCode.OK)]
        public IActionResult GetListShort()
        {
            IExcursionsServiceGetListShortRes serviceResponse = _excursionsService.GetListShort();
            IExcursionsGetListShortRes response = _mapper.Map<ExcursionsGetListShortRes>(serviceResponse);
            return Ok(response);
        }
    }
}