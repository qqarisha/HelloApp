using HelloApp.Classes;

namespace HelloApp.Interfaces
{
    public interface IUserBookRepository
    {
        void MarkAsRead(int userId, int bookId);

        IEnumerable<Book?> GetReadBooks(int userId);
    }
}
