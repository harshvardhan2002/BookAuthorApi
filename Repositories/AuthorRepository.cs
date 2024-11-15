using AuthorBooksAPI.Data;
using AuthorBooksAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthorBooksAPI.Repositories
{
    public class AuthorRepository:IAuthorRepository
    {
        private readonly BookAuthorDbContext _context;

        public AuthorRepository(BookAuthorDbContext context)
        {
            _context = context;
        }

        public List<Author> GetAll()
        {
            return _context.Authors.Include(a => a.Book).Include(a => a.AuthorDetails).ToList();
        }

        public Author GetById(int id)
        {
            return _context.Authors.AsNoTracking().FirstOrDefault(a => a.AuthorId == id);
        }

        public void Add(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        public void Update(Author author)
        {
            _context.Authors.Update(author);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var author = _context.Authors.FirstOrDefault(a => a.AuthorId == id);
            if (author != null)
            {
                _context.Authors.Remove(author);
                _context.SaveChanges();
            }
        }
    }
}
