using OA.Entity;
using OA.Repo.Interface;
using OA.Service.Interface;

namespace OA.Service.Implementation
{
    public class BookService: IBookService
    {
        private IRepo<Book> bookRepository;
        //private IRepository<Author> authorRepository;

        public BookService(IRepo<Book> bookRepository)
        {
            this.bookRepository = bookRepository;
            //this.authorRepository = authorRepository;
        }

        public IEnumerable<Book> GetBooks()
        {
            return bookRepository.GetAll();
        }

        public IEnumerable<Book> GetBooksByAuthor(int authorId)
        {
            return bookRepository.GetAll().Where(b => b.AuthorId == authorId);
        }

        public Book GetBook(int id)
        {
            return bookRepository.Get(id);
        }

        public void InsertBook(Book book)
        {
            bookRepository.Insert(book);
        }

        public void UpdateBook(Book book)
        {
            bookRepository.Update(book);
        }

        public void DeleteBook(int id)
        {
            Book book = bookRepository.Get(id);
            bookRepository.Delete(book);
            bookRepository.SaveChanges();
        }
    }
}
