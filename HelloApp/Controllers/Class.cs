using Microsoft.AspNetCore.Mvc;
using HelloApp.Services;

namespace MvcApp.Controllers
{
    public class ApiController : Controller
    {
        private ITimeService timeService;
        private IPingService pingService;

        public ApiController(ITimeService timeservice, IPingService pingservice)
        {
            timeService = timeservice;
            pingService = pingservice;
        }

        [ActionName("healthcheck")]
        [HttpGet]
        public async Task Index()
        {
            Response.StatusCode = 200;
            await Response.WriteAsync("OK");
        }

        [HttpGet("api/config/myfield")]
        public async Task Conf()
        {
            var config = HttpContext.RequestServices.GetService<IConfiguration>();
            var myField = config["AppSettings:MyField"];
            await Response.WriteAsync($"value: {myField}");
        }

        [HttpGet("api/time")]
        public async Task Time()
        {
            await Response.WriteAsync(timeService.GetTime().ToString());
        }

        [HttpPost("api/pings")]
        public async Task Ping()
        {
            pingService.Ping();
        }

        [HttpGet("api/pings")]
        public async Task GetPing()
        {
            await Response.WriteAsync(pingService.GetPings().ToString());
        }

    }
}
