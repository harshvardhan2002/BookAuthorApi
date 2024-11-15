using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AuthorBooksAPI.Models
{
    public class AuthorDetails
    {

        [Key]
        public int AuthorDetailsId { get; set; }

        public string City { get; set; }
        public string Country { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        public Author? Author { get; set; }

        [ForeignKey("Author")]
        public int AuthorId { get; set; }
    }
}
