using OA.Entity;

namespace OA.Service.Interface
{
    public interface IBookService
    {
        IEnumerable<Book> GetBooks();
        Book GetBook(int id);
        void InsertBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(int id);
        public IEnumerable<Book> GetBooksByAuthor(int authorId);
    }
}
