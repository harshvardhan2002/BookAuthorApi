using AuthorBooksAPI.Models;
using AuthorBooksAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuthorBooksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorDetailsController : ControllerBase
    {
        private readonly IAuthorDetailsService _service;

        public AuthorDetailsController(IAuthorDetailsService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var details = _service.GetAuthorDetails();
            return Ok(details);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var details = _service.GetAuthorDetailsById(id);
            if (details != null)
            {
                return Ok(details);
            }
            return NotFound("No author details found with this ID");
        }

        [HttpPost]
        public IActionResult Add([FromBody] AuthorDetails details)
        {
            _service.AddAuthorDetails(details);
            return CreatedAtAction(nameof(Get), new { id = details.AuthorDetailsId }, details);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, AuthorDetails details)
        {
            details.AuthorDetailsId = id;
            var updated = _service.UpdateAuthorDetails(details);
            if (updated)
            {
                return Ok(details);
            }
            return NotFound("No author details found with this ID");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _service.DeleteAuthorDetails(id);
            if (deleted)
            {
                return Ok();
            }
            return NotFound("No author details found with this ID");
        }
    }
}
