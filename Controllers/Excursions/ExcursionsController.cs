using AutoMapper;
using JDPodrozeAPI.Controllers.Excursions.Contracts.Requests;
using JDPodrozeAPI.Controllers.Excursions.Contracts.Responses;
using JDPodrozeAPI.Services.Excursions;
using JDPodrozeAPI.Services.Excursions.Contracts.Requests;
using JDPodrozeAPI.Services.Excursions.Contracts.Responses;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("GetImageNew/{fileId}/{resolution}/{extension}")]
        [ProducesResponseType(typeof(FileContentResult), (int) HttpStatusCode.OK)]
        [ResponseCache(Duration = 2592000, Location = ResponseCacheLocation.Client)]
        public async Task<FileContentResult> GetImageNew(int fileId, string resolution, string extension)
        {
            byte[] imageBytes = await _excursionsService.GetImageNew(fileId, resolution, extension);
            return File(imageBytes, $"image/{extension}", $"{fileId}");
        }

        [HttpGet("GetItem/{id}")]
        [ProducesResponseType(typeof(IExcursionsGetItemRes), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> GetItem(int id)
        {
            IExcursionsServiceGetItemRes? serviceResponse = await _excursionsService.GetItem(id);
            IExcursionsGetItemRes response = _mapper.Map<ExcursionsGetItemRes>(serviceResponse);
            return Ok(response);
        }

        [Authorize(Roles = "ADMINISTRATOR")]
        [HttpGet("GetItemWithImages/{id}")]
        [ProducesResponseType(typeof(IExcursionsGetItemRes), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetItemWithImages(int id)
        {
            IExcursionsServiceGetItemRes? serviceResponse = await _excursionsService.GetItem(id, true, true);
            IExcursionsGetItemRes response = _mapper.Map<ExcursionsGetItemRes>(serviceResponse);
            return Ok(response);
        }

        [Authorize(Roles = "ADMINISTRATOR")]
        [HttpPost("GetList")]
        public IActionResult GetList([FromBody] ExcursionsGetListReq request)
        {
            var response = _excursionsService.GetList(request);
            return Ok(response);
        }

        [HttpGet("GetListShort")]
        [ProducesResponseType(typeof(IExcursionsGetListShortRes), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> GetListShort()
        {
            IExcursionsServiceGetListShortRes serviceResponse = await _excursionsService.GetListShortAsync();
            IExcursionsGetListShortRes response = _mapper.Map<IExcursionsGetListShortRes>(serviceResponse);
            return Ok(response);
        }

        [Authorize(Roles = "ADMINISTRATOR")]
        [HttpPost("Add")]
        [ProducesResponseType((int) HttpStatusCode.OK)]
        public async Task<IActionResult> Add([FromBody] ExcursionsAddReq request)
        {
            ExcursionsServiceAddReq serviceRequest = _mapper.Map<ExcursionsServiceAddReq>(request);
            await _excursionsService.Add(serviceRequest);
            return Ok();
        }

        [Authorize(Roles = "ADMINISTRATOR")]
        [HttpPost("Edit")]
        [ProducesResponseType((int) HttpStatusCode.OK)]
        public async Task<IActionResult> Edit([FromBody] ExcursionsEditReq request)
        {
            ExcursionsServiceEditReq serviceRequest = _mapper.Map<ExcursionsServiceEditReq>(request);
            await _excursionsService.Edit(serviceRequest);
            return Ok();
        }

        [Authorize(Roles = "ADMINISTRATOR")]
        [HttpGet("ChangeToTemplate/{id}")]
        [ProducesResponseType((int) HttpStatusCode.OK)]
        public async Task<IActionResult> ChangeToTemplate(int id)
        {
            await _excursionsService.ChangeToTemplate(id);
            return Ok();
        }

        [HttpPost("Enroll")]
        [ProducesResponseType(typeof(Guid?), (int) HttpStatusCode.OK)]
        [ProducesResponseType((int) HttpStatusCode.BadRequest)]
        public IActionResult Enroll([FromBody] ExcursionsEnrollReq request)
        {
            ExcursionsServiceEnrollReq serviceRequest = _mapper.Map<ExcursionsServiceEnrollReq>(request);
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