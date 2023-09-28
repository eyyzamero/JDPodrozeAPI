using AutoMapper;
using JDPodrozeAPI.Controllers.Excursions.Contracts.Requests;
using JDPodrozeAPI.Controllers.Excursions.Contracts.Responses;
using JDPodrozeAPI.Services.Excursions;
using JDPodrozeAPI.Services.Excursions.Contracts.Requests;
using JDPodrozeAPI.Services.Excursions.Contracts.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
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

        [HttpGet("GetImage/{fileId}")]
        [ProducesResponseType(typeof(FileContentResult), (int) HttpStatusCode.OK)]
        [ResponseCache(Duration = 2592000, Location = ResponseCacheLocation.Client)]
        public async Task<FileContentResult> GetImage(int fileId)
        {
            IExcursionsServiceGetImageRes? serviceResponse = await _excursionsService.GetImage(fileId);
            return File(serviceResponse.RawImageBytes, $"image/{serviceResponse.Type}", serviceResponse.Name);
        }

        [HttpGet("GetItem/{id}")]
        [ProducesResponseType(typeof(IExcursionsGetItemRes), (int) HttpStatusCode.OK)]
        public IActionResult GetItem(int id)
        {
            IExcursionsServiceGetItemRes? serviceResponse = _excursionsService.GetItem(id);
            IExcursionsGetItemRes response = _mapper.Map<ExcursionsGetItemRes>(serviceResponse);
            return Ok(response);
        }

        [Authorize(Roles = "ADMINISTRATOR")]
        [HttpGet("GetList")]
        public IActionResult GetList()
        {
            var response = _excursionsService.GetList();
            return Ok(response);
        }

        [HttpGet("GetListShort")]
        [ProducesResponseType(typeof(IExcursionsGetListShortRes), (int) HttpStatusCode.OK)]
        public IActionResult GetListShort()
        {
            IExcursionsServiceGetListShortRes serviceResponse = _excursionsService.GetListShort();
            IExcursionsGetListShortRes response = _mapper.Map<ExcursionsGetListShortRes>(serviceResponse);
            return Ok(response);
        }

        [Authorize(Roles = "ADMINISTRATOR")]
        [HttpPost("Add")]
        [ProducesResponseType((int) HttpStatusCode.OK)]
        public IActionResult Add([FromBody] ExcursionsAddReq request)
        {
            ExcursionsServiceAddReq serviceRequest = _mapper.Map<ExcursionsServiceAddReq>(request);
            _excursionsService.Add(serviceRequest);
            return Ok();
        }

        [Authorize(Roles = "ADMINISTRATOR")]
        [HttpPost("Edit")]
        [ProducesResponseType((int) HttpStatusCode.OK)]
        public IActionResult Edit([FromBody] ExcursionsEditReq request)
        {
            ExcursionsServiceEditReq serviceRequest = _mapper.Map<ExcursionsServiceEditReq>(request);
            _excursionsService.Edit(serviceRequest);
            return Ok();
        }

        [HttpPost("Enroll")]
        [ProducesResponseType(typeof(Guid?), (int) HttpStatusCode.OK)]
        [ProducesResponseType((int) HttpStatusCode.BadRequest)]
        public IActionResult Enroll([FromBody] ExcursionsEnrollReq request)
        {
            IExcursionsServiceEnrollReq serviceRequest = _mapper.Map<ExcursionsServiceEnrollReq>(request);
            Guid? serviceResponse = _excursionsService.Enroll(serviceRequest);
            return Ok(serviceResponse);
        }

        [Authorize(Roles = "ADMINISTRATOR")]
        [HttpDelete("Delete/{id}")]
        [ProducesResponseType((int) HttpStatusCode.OK)]
        public IActionResult Delete(int id)
        {
            _excursionsService.Delete(id);
            return Ok();
        }
    }
}