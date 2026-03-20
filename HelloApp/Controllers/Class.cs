using Microsoft.AspNetCore.Mvc;

namespace MvcApp.Controllers
{
    public class ApiController : Controller
    {
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

    }
}