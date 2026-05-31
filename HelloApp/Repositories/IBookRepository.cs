using HelloApp.Classes;

namespace HelloApp.Repositories
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAll();

        Book? GetById(int id);

        void Create(Book entity);

        void Update(Book entity);

        void Delete(int id);
    }
}

