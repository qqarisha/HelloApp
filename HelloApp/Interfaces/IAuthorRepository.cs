using HelloApp.Classes;

namespace HelloApp.Interfaces
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> GetAll();

        Author? GetById(int id);

        void Create(Author entity);

        void Update(Author entity);

        void Delete(int id);

        IEnumerable<Book>? GetBooksByAuthorId(int authorId);

    }
}