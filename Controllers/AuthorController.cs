using AuthorBooksAPI.Models;
using AuthorBooksAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuthorBooksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _service;

        public AuthorController(IAuthorService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var authors = _service.GetAuthors();
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var author = _service.GetAuthorById(id);
            if (author != null)
            {
                return Ok(author);
            }
            return NotFound("No author found with this ID");
        }

        [HttpPost]
        public IActionResult Add(Author author)
        {
            _service.AddAuthor(author);
            return CreatedAtAction(nameof(Get), new { id = author.AuthorId }, author);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Author author)
        {
            author.AuthorId = id;
            var updated = _service.UpdateAuthor(author);
            if (updated)
            {
                return Ok(author);
            }
            return NotFound("No author found with this ID");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _service.DeleteAuthor(id);
            if (deleted)
            {
                return Ok();
            }
            return NotFound("No author found with this ID");
        }
    }
}
