using Microsoft.AspNetCore.Mvc;
using HelloApp.Interfaces;
using HelloApp.Classes;

namespace MvcApp.Controllers
{
    public class UserController(IUserRepository userRepository) : Controller
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IUserBookRepository _userBookRepository;

        [HttpGet("api/users")]
        public async Task<IActionResult> AllUsers()
        {
            return Ok(_userRepository.GetAll());
        }

        [HttpGet("api/users/{id}")]
        public async Task<IActionResult> UserByID(int id)
        {
            return Ok(_userRepository.GetById(id));
        }

        [HttpPost("api/users")]
        public async Task<IActionResult> NewUser(User user)
        {
            _userRepository.Create(user);
            return Ok();
        }

        [HttpPut("api/users/{id}")]
        public async Task<IActionResult> ChangeUser(int id, User user)
        {
            user.Id = id;
            _userRepository.Update(user);
            return Ok();
        }

        [HttpDelete("api/users/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            _userRepository.Delete(id);
            return Ok();
        }

        [HttpPost("api/users/{userId}/books/{bookId}/read")]
        public IActionResult MarkAsRead(int userId, int bookId)
        {
            _userBookRepository.MarkAsRead(userId, bookId);
            return Ok();
        }

        [HttpGet("api/users/{userId}/books")]
        public IActionResult GetReadBooks(int userId)
        {
            var books = _userBookRepository.GetReadBooks(userId);
            return Ok(books);
        }
    }
}
