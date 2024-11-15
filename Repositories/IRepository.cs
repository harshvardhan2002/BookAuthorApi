using Microsoft.Identity.Client;

namespace AuthorBooksAPI.Repositories
{
    public interface IRepository<T>
    {
        public int Add(T entity);
        public IQueryable<T> GetAll();
        public T Update(T entity);
        public T GetById(int id);
        public void Delete(T entity);
    }
}
