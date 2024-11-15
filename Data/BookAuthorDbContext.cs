using AuthorBooksAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthorBooksAPI.Data
{
    public class BookAuthorDbContext:DbContext
    {
        public BookAuthorDbContext(DbContextOptions<BookAuthorDbContext> options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<AuthorDetails> AuthorDetails { get; set; }
    }
}
