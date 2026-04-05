using Microsoft.AspNetCore.Mvc;
using HelloApp.Services;

namespace MvcApp.Controllers
{
    public class ApiController : Controller
    {
        private TimeService timeService;

        public ApiController(TimeService timeservice)
        {
            timeService = timeservice;
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
            await Response.WriteAsync(timeService.GetTime());
        }

    }
}