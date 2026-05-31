using HelloApp.Classes;

namespace HelloApp.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();

        User GetByID(int id);

        void Create(User entity);

        void Update(User entity);

        void Delete(int id);
    }
}