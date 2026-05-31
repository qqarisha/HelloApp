using HelloApp.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelloApp.EntityConfigurations;

public class BookToUserConfiguration : IEntityTypeConfiguration<BookToUser>
{
    public void Configure(EntityTypeBuilder<BookToUser> builder)
    {
        builder.HasKey(x => new { x.BookId, x.UserId });

        builder.HasOne(x => x.Book)
            .WithMany(x => x.BookToUsers)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.User)
            .WithMany(x => x.BookToUsers)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
