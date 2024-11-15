using AuthorBooksAPI.Models;

namespace AuthorBooksAPI.Repositories
{
    public interface IAuthorDetailsRepository
    {
        List<AuthorDetails> GetAll();
        AuthorDetails GetById(int id);
        void Add(AuthorDetails details);
        void Update(AuthorDetails details);
        void Delete(int id);
    }
}
