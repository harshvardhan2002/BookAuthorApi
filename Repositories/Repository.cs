using AuthorBooksAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace AuthorBooksAPI.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly BookAuthorDbContext _context;
        private readonly DbSet<T> _table;
        public Repository(BookAuthorDbContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public int Add(T entity)
        {
            _table.Add(entity);
            return _context.SaveChanges();
            
        }

        public IQueryable<T> GetAll()
        {
            return _table.AsQueryable();
        }

        public T Update(T entity)
        {
            _table.Update(entity);
            _context.SaveChanges();
            return entity;  
        }


        public T GetById(int id)
        {
            return _table.Find(id);
        }
        public void Delete(T entity)
        {
            _table.Remove(entity);
            _context.SaveChanges();
        }
    }
}
