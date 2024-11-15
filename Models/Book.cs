using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AuthorBooksAPI.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        public string BookName { get; set; }
        public double Price { get; set; }
        public DateTime DateOfRelease { get; set; }

        public Author? Author { get; set; }

        [ForeignKey("Author")]
        public int AuthorId { get; set; }

    }
}
