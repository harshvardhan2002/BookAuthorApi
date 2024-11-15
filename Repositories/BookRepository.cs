using AuthorBooksAPI.Data;
using AuthorBooksAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthorBooksAPI.Repositories
{
    public class BookRepository:IBookRepository
    {
        private readonly BookAuthorDbContext _context;

        public BookRepository(BookAuthorDbContext context)
        {
            _context = context;
        }

        public List<Book> GetAll()
        {
            return _context.Books.Include(b => b.Author).ToList();
        }

        public Book GetById(int id)
        {
            return _context.Books.AsNoTracking().FirstOrDefault(b => b.BookId == id);
        }

        public void Add(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void Update(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.BookId == id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }
    }
}
