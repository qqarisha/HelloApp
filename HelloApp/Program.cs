using HelloApp.Interfaces;
using HelloApp.Repositories;
using HelloApp.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<IPingService, PingService>();
builder.Services.AddTransient<ITimeService, TimeService>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();

builder.Services.AddScoped<ApplicationContextInitializer>();

var app = builder.Build();

using var scope = app.Services.CreateScope();
var initializer = scope.ServiceProvider.GetRequiredService<ApplicationContextInitializer>();

initializer.InitializeDB().Wait();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}");

app.Run();