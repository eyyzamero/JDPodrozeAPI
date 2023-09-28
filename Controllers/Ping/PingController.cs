using Microsoft.AspNetCore.Mvc;

namespace JDPodrozeAPI.Controllers.Ping
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class PingController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return Ok("ping");
        }
    }
}