using AuthorBooksAPI.Models;
using AuthorBooksAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuthorBooksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController:ControllerBase
    {
        private readonly IBookService _service;

        public BookController(IBookService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var books = _service.GetBooks();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var book = _service.GetBookById(id);
            if (book != null)
            {
                return Ok(book);
            }
            return NotFound("No book found with this ID");
        }

        [HttpPost]
        public IActionResult Add(Book book)
        {
            _service.AddBook(book);
            return CreatedAtAction(nameof(Get), new { id = book.BookId }, book);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Book book)
        {
            book.BookId = id;
            var updated = _service.UpdateBook(book);
            if (updated)
            {
                return Ok(book);
            }
            return NotFound("No book found with this ID");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _service.DeleteBook(id);
            if (deleted)
            {
                return Ok();
            }
            return NotFound("No book found with this ID");
        }
    }
}
