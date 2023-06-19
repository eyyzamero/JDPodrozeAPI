using AutoMapper;
using JDPodrozeAPI.Controllers.Account.Contracts.Requests;
using JDPodrozeAPI.Controllers.Account.Contracts.Responses;
using JDPodrozeAPI.Services.Account;
using JDPodrozeAPI.Services.Account.Contracts.Requests;
using JDPodrozeAPI.Services.Account.Contracts.Responses;
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
        public IActionResult Login([FromBody] AccountLoginReq request)
        {
            IAccountServiceLoginReq serviceRequest = _mapper.Map<AccountServiceLoginReq>(request);
            string? response = _accountService.TryToLogin(serviceRequest);
            return response != null ? Ok(response) : BadRequest("Invalid credentials");
        }

        [HttpPost("Register")]
        [ProducesResponseType(typeof(IAccountRegisterRes), (int) HttpStatusCode.OK)]
        public IActionResult Register([FromBody] AccountRegisterReq request)
        {
            IAccountServiceRegisterReq serviceRequest = _mapper.Map<AccountServiceRegisterReq>(request);
            IAccountServiceRegisterRes serviceResponse = _accountService.Register(serviceRequest);
            IAccountRegisterRes response = _mapper.Map<AccountRegisterRes>(serviceResponse);
            return Ok(response);
        }
    }
}