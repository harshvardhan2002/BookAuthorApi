using System.ComponentModel.DataAnnotations;

namespace AuthorBooksAPI.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }

        public Book? Book { get; set; }
        public AuthorDetails? AuthorDetails { get; set; }
    }
}
