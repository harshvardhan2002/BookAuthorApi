using AuthorBooksAPI.Models;
using AuthorBooksAPI.Repositories;

namespace AuthorBooksAPI.Services
{
    public class AuthorService:IAuthorService
    {
        private readonly IRepository<Author> _repository;

        public AuthorService(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public List<Author> GetAuthors()
        {
            return _repository.GetAll().ToList();
        }

        public Author GetAuthorById(int id)
        {
            return _repository.GetById(id);
        }

        public void AddAuthor(Author author)
        {
            _repository.Add(author);
        }

        public bool UpdateAuthor(Author author)
        {
            var existingAuthor = _repository.GetById(author.AuthorId);
            if (existingAuthor != null)
            {
                _repository.Update(author);
                return true;
            }
            return false;
        }

        public bool DeleteAuthor(int id)
        {
            var author = _repository.GetById(id);
            if (author != null)
            {
                _repository.Delete(author);
                return true;
            }
            return false;
        }
    }
}
