using AuthorBooksAPI.Models;
using AuthorBooksAPI.Repositories;

namespace AuthorBooksAPI.Services
{
    public class AuthorDetailsService: IAuthorDetailsService
    {
        private readonly IRepository<AuthorDetails> _repository;

        public AuthorDetailsService(IRepository<AuthorDetails> repository)
        {
            _repository = repository;
        }

        public List<AuthorDetails> GetAuthorDetails()
        {
            return _repository.GetAll().ToList();
        }

        public AuthorDetails GetAuthorDetailsById(int id)
        {
            return _repository.GetById(id);
        }

        public void AddAuthorDetails(AuthorDetails details)
        {
            _repository.Add(details);
        }

        public bool UpdateAuthorDetails(AuthorDetails details)
        {
            var existingDetails = _repository.GetById(details.AuthorDetailsId);
            if (existingDetails != null)
            {
                _repository.Update(details);
                return true;
            }
            return false;
        }

        public bool DeleteAuthorDetails(int id)
        {
            var details = _repository.GetById(id);
            if (details != null)
            {
                _repository.Delete(details);
                return true;
            }
            return false;
        }
    }
}
