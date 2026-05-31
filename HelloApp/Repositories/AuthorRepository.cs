using HelloApp.Classes;

namespace HelloApp.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private ApplicationContext _context;

        public AuthorRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Author> GetAll()
        {
            return _context.Authors;
        }

        public Author? GetById(int id)
        {
            return _context.Authors.Find(id);
        }

        public void Create(Author entity)
        {
            _context.Authors.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Author entity)
        {
            _context.Authors.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var author = _context.Authors.Find(id);
            if (author != null)
            {
                _context.Authors.Remove(author);
            }
            _context.SaveChanges();
        }
    }
}