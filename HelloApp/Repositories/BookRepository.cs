using HelloApp.Classes;
using HelloApp.Interfaces;
using HelloApp.Services;

namespace HelloApp.Repositories
{
    public class BookRepository : IBookRepository
    {
        private ApplicationContext _context;

        public BookRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> GetAll()
        {
            return _context.Books;
        }

        public Book? GetById(int id)
        {
            return _context.Books.Find(id);
        }

        public void Create(Book entity)
        {
            _context.Books.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Book entity)
        {
            _context.Books.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var book = _context.Books.Find(id);
            if (book != null)
            {
                _context.Books.Remove(book);
            }
            _context.SaveChanges();
        }
    }
}


