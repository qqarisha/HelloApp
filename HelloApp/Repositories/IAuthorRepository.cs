using HelloApp.Classes;

namespace HelloApp.Repositories
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> GetAll();

        Author? GetById(int id);

        void Create(Author entity);

        void Update(Author entity);

        void Delete(int id);
    }
}