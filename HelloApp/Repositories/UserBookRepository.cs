using HelloApp.Classes;
using HelloApp.Interfaces;
using HelloApp.Services;
using Microsoft.EntityFrameworkCore;

namespace HelloApp.Repositories
{
    public class UserBookRepository: IUserBookRepository
    {
        private ApplicationContext _context;

        public void MarkAsRead(int userId, int bookId)
        {
            var entity = new BookToUser
            {
                UserId = userId,
                BookId = bookId
            };

            _context.BookToUsers.Add(entity);
            _context.SaveChanges();
        }

        public IEnumerable<Book?> GetReadBooks(int userId)
        {
            return _context.BookToUsers
                .Where(x => x.UserId == userId)
                .Include(x => x.Book)
                .Select(x => x.Book)
                .ToList();
        }


    }
}
