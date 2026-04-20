using Microsoft.EntityFrameworkCore;

namespace HelloApp.Classes
{
    public class ApplicationContext: DbContext
    {
        public DbSet<User> Users { get; set; } = null!;

        public DbSet<Author> Authors { get; set; } = null!;

        public DbSet<Book> Books { get; set; } = null!;

        public DbSet<BookToUser> BookToUsers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options)
        {
            
        }
    }
}
