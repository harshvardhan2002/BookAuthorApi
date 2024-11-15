using AuthorBooksAPI.Models;

namespace AuthorBooksAPI.Services
{
    public interface IBookService
    {
        List<Book> GetBooks();
        Book GetBookById(int id);
        void AddBook(Book book);
        bool UpdateBook(Book book);
        bool DeleteBook(int id);
    }
}
