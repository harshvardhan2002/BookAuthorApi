using AuthorBooksAPI.Models;
using AuthorBooksAPI.Repositories;

namespace AuthorBooksAPI.Services
{
    public class BookService:IBookService
    {
        private readonly IRepository<Book> _repository;

        public BookService(IRepository<Book> repository)
        {
            _repository = repository;
        }

        public List<Book> GetBooks()
        {
            var entityQuery = _repository.GetAll();
            var customer = entityQuery.ToList();
            return customer;
            //return _repository.GetAll().ToList();
        }

        public Book GetBookById(int id)
        {
            return _repository.GetById(id);
        }

        public void AddBook(Book book)
        {
            _repository.Add(book);
        }

        public bool UpdateBook(Book book)
        {
            var existingBook = _repository.GetById(book.BookId);
            if (existingBook != null)
            {
                _repository.Update(book);
                return true;
            }
            return false;
        }

        public bool DeleteBook(int id)
        {
            var book = _repository.GetById(id);
            if (book != null)
            {
                _repository.Delete(book);
                return true;
            }
            return false;
        }
    }
}
