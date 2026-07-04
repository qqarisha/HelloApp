using HelloApp.Classes;

namespace HelloApp.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();

        User? GetById(int id);

        void Create(User entity);

        void Update(User entity);

        void Delete(int id);
    }
}