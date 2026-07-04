using Microsoft.AspNetCore.Mvc;
using HelloApp.Interfaces;
using HelloApp.Classes;

namespace MvcApp.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        [HttpGet("api/authors")]
        public async Task<IActionResult> AllAuthors()
        {
            return Ok(_authorRepository.GetAll());
        }

        [HttpGet("api/authors/{id}")]
        public async Task<IActionResult> AuthorByID(int id)
        {
            return Ok(_authorRepository.GetById(id));
        }

        [HttpPost("api/authors")]
        public async Task<IActionResult> NewAuthor(Author Author)
        {
            _authorRepository.Create(Author);
            return Ok();
        }

        [HttpPut("api/authors/{id}")]
        public async Task<IActionResult> ChangeAuthor(int id, Author Author)
        {
            Author.Id = id;
            _authorRepository.Update(Author);
            return Ok();
        }

        [HttpDelete("api/authors/{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            _authorRepository.Delete(id);
            return Ok();
        }

        [HttpGet("api/authors/{id}/books")]
        public async Task<IActionResult> BookByID(int id)
        {
            return Ok(_authorRepository.GetBooksByAuthorId(id));
        }
    }
}
