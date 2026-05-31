using HelloApp.Classes;
using HelloApp.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<IPingService, PingService>();
builder.Services.AddTransient<ITimeService, TimeService>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(connectionString));

var app = builder.Build();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}");

app.Run();