using Microsoft.AspNetCore.Mvc;
using HelloApp.Interfaces;

namespace MvcApp.Controllers
{
    public class ApiController(ITimeService timeService, IPingService pingService) : Controller
    {
        [ActionName("healthcheck")]
        [HttpGet]
        public async Task<IActionResult> Index() => Ok();

        [HttpGet("api/config/myfield")]
        public async Task<IActionResult> Conf()
        {
            var config = HttpContext.RequestServices.GetService<IConfiguration>();
            var myField = config["AppSettings:MyField"];
            return Ok($"value: {myField}");
        }

        [HttpGet("api/time")]
        public async Task<IActionResult> Time() => Ok(timeService.GetTime().ToString());

        [HttpPost("api/pings")]
        public async Task<IActionResult> Ping()
        {
            pingService.Ping();
            return Ok();
        }

        [HttpGet("api/pings")]
        public async Task<IActionResult> GetPing() => Ok(pingService.GetPings().ToString());
    }
}
