using HelloApp.Classes;

namespace HelloApp.Interfaces
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

