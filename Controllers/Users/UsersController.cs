using AutoMapper;
using JDPodrozeAPI.Services;
using JDPodrozeAPI.Services.Users.Contracts.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JDPodrozeAPI.Controllers.Users
{
    [Authorize(Roles = "ADMINISTRATOR")]
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class UsersController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUsersService _usersService;
        
        public UsersController(IMapper mapper, IUsersService usersService)
        {
            _mapper = mapper;
            _usersService = usersService;
        }

        [HttpGet]
        public async Task<ActionResult> GetList()
        {
            IUsersGetListRes response = await _usersService.GetList();
            return Ok(response);
        }
    }
}