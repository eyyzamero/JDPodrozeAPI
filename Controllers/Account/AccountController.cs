using AutoMapper;
using JDPodrozeAPI.Controllers.Account.Contracts.Requests;
using JDPodrozeAPI.Controllers.Account.Contracts.Responses;
using JDPodrozeAPI.Services.Account;
using JDPodrozeAPI.Services.Account.Contracts.Requests;
using JDPodrozeAPI.Services.Account.Contracts.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace JDPodrozeAPI.Controllers.Account
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class AccountController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IAccountService _accountService;

        public AccountController(IMapper mapper, IAccountService accountService)
        {
            _mapper = mapper;
            _accountService = accountService;
        }

        [HttpPost("Login")]
        [ProducesResponseType(typeof(string), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> Login([FromBody] AccountLoginReq request)
        {
            IAccountServiceLoginReq serviceRequest = _mapper.Map<IAccountServiceLoginReq>(request);
            string? response = await _accountService.TryToLoginAsync(serviceRequest);
            return response != null ? Ok(response) : BadRequest("Invalid credentials");
        }

        [HttpPost("Register")]
        [ProducesResponseType(typeof(IAccountRegisterRes), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> Register([FromBody] AccountRegisterReq request)
        {
            IAccountServiceRegisterReq serviceRequest = _mapper.Map<IAccountServiceRegisterReq>(request);
            IAccountServiceRegisterRes serviceResponse = await _accountService.RegisterAsync(serviceRequest);
            IAccountRegisterRes response = _mapper.Map<IAccountRegisterRes>(serviceResponse);
            return Ok(response);
        }

        [HttpPost("IsLoginAvailable")]
        [ProducesResponseType(typeof(bool), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> IsLoginAvailable([FromBody] AccountIsLoginAvailableReq request)
        {
            bool response = await _accountService.IsLoginAvailable(request.Login, request.CurrentLogin);
            return Ok(response);
        }

        [HttpPost("AddOrEdit")]
        [ProducesResponseType(typeof(int?), (int) HttpStatusCode.OK)]
        [Authorize(Roles = "ADMINISTRATOR")]
        public async Task<IActionResult> AddOrEdit([FromBody] AccountAddOrEditReq request)
        {
            int? response = await _accountService.AddOrEditAsync(request);
            return Ok(response);
        }

        [HttpDelete("Delete/{id}")]
        [ProducesResponseType(typeof(void), (int) HttpStatusCode.OK)]
        [Authorize(Roles = "ADMINISTRATOR")]
        public async Task<IActionResult> Delete(int id)
        {
            await _accountService.DeleteAsync(id);
            return Ok();
        }
    }
}