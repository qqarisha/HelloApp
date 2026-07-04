using Microsoft.AspNetCore.Mvc;
using HelloApp.Interfaces;
using HelloApp.Classes;

namespace MvcApp.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet("api/books")]
        public async Task<IActionResult> AllBooks()
        {
            return Ok(_bookRepository.GetAll());
        }

        [HttpGet("api/books/{id}")]
        public async Task<IActionResult> BookByID(int id)
        {
            return Ok(_bookRepository.GetById(id));
        }

        [HttpPost("api/books")]
        public async Task<IActionResult> NewBook(Book book)
        {
            _bookRepository.Create(book);
            return Ok();
        }

        [HttpPut("api/books/{id}")]
        public async Task<IActionResult> ChangeBook(int id, Book book)
        {
            book.Id = id;
            _bookRepository.Update(book);
            return Ok();
        }

        [HttpDelete("api/books/{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            _bookRepository.Delete(id);
            return Ok();
        }
    }
}
