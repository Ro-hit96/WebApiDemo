using WebApiDemo.Models;

namespace WebApiDemo.Service
{
    public interface IBookServices
    {
        IEnumerable<Book> GetBooks();
        Book GetBookById(int id);
        int AddBook(Book book);
        int UpdateBook(Book book);
        int DeleteBook(int id);
    }
}
