namespace HelloApp.Classes
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int? AuthorId { get; set; }

        public Author? Author { get; set; }

        public ICollection<BookToUser> BookToUsers { get; set; } = [];
    }
}