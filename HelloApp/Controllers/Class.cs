using Microsoft.AspNetCore.Mvc;
using HelloApp.Services;

namespace MvcApp.Controllers
{
    public class ApiController(ITimeService timeService, IPingService pingService) : Controller
    {
        [ActionName("healthcheck")]
        [HttpGet]
        public async Task Index() => Ok();

        [HttpGet("api/config/myfield")]
        public async Task Conf()
        {
            var config = HttpContext.RequestServices.GetService<IConfiguration>();
            var myField = config["AppSettings:MyField"];
            await Response.WriteAsync($"value: {myField}");
        }

        [HttpGet("api/time")]
        public async Task Time() => Ok(timeService.GetTime().ToString());

        [HttpPost("api/pings")]
        public async Task Ping() => pingService.Ping();

        [HttpGet("api/pings")]
        public async Task<IActionResult> GetPing() => Ok(pingService.GetPings().ToString());
    }
}
