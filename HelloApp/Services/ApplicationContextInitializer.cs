using Microsoft.EntityFrameworkCore;

namespace HelloApp.Services
{
    public class ApplicationContextInitializer(ApplicationContext context)
    {
        public async Task InitializeDB()
        {
            if ((await context.Database.GetPendingMigrationsAsync()).Any())
                await context.Database.MigrateAsync();
        }
    }
}
