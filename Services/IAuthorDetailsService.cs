using AuthorBooksAPI.Models;

namespace AuthorBooksAPI.Services
{
    public interface IAuthorDetailsService
    {
        List<AuthorDetails> GetAuthorDetails();
        AuthorDetails GetAuthorDetailsById(int id);
        void AddAuthorDetails(AuthorDetails details);
        bool UpdateAuthorDetails(AuthorDetails details);
        bool DeleteAuthorDetails(int id);
    }
}
