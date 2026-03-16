var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Map("/api/healthcheck", async (context) =>
{
    if (context.Request.Method == "GET")
    {
        context.Response.StatusCode = 200;
        await context.Response.WriteAsync("OK");
    }
});

app.Map("/api/config/myfield", async (HttpContext context, IConfiguration config) =>
{
    if (context.Request.Method == "GET")
    {
        var myField = config["AppSettings:MyField"];
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsync($"value: {myField}");
    }
});

app.Run();