using AuthorBooksAPI.Models;

namespace AuthorBooksAPI.Services
{
    public interface IAuthorService
    {
        public List<Author> GetAuthors();
        public Author GetAuthorById(int id);
        public void AddAuthor(Author author);
        public bool UpdateAuthor(Author author);
        public bool DeleteAuthor(int id);
    }
}
