using AuthorBooksAPI.Data;
using AuthorBooksAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthorBooksAPI.Repositories
{
    public class AuthorDetailsRepository:IAuthorDetailsRepository
    {
        private readonly BookAuthorDbContext _context;

        public AuthorDetailsRepository(BookAuthorDbContext context)
        {
            _context = context;
        }

        public List<AuthorDetails> GetAll()
        {
            return _context.AuthorDetails.Include(ad => ad.Author).ToList();
        }

        public AuthorDetails GetById(int id)
        {
            return _context.AuthorDetails.AsNoTracking().FirstOrDefault(ad => ad.AuthorDetailsId == id);
        }

        public void Add(AuthorDetails details)
        {
            _context.AuthorDetails.Add(details);
            _context.SaveChanges();
        }

        public void Update(AuthorDetails details)
        {
            _context.AuthorDetails.Update(details);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var details = _context.AuthorDetails.FirstOrDefault(ad => ad.AuthorDetailsId == id);
            if (details != null)
            {
                _context.AuthorDetails.Remove(details);
                _context.SaveChanges();
            }
        }
    }
}
