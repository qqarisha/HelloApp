using HelloApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<IPingService, PingService>();
builder.Services.AddTransient<ITimeService, TimeService>();


var app = builder.Build();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}");

app.Run();