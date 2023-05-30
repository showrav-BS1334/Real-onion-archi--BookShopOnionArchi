using OA.Entity;
using OA.Repo.Interface;
using OA.Service.Interface;

namespace OA.Service.Implementation
{
    public class AuthorService : IAuthorService
    {
        private IRepo<Author> authorRepository;
        //private IRepo<Book> bookRepository;

        public AuthorService(IRepo<Author> authorRepository)
        {
            this.authorRepository = authorRepository;
            //this.bookRepository = bookRepository;
        }

        public IEnumerable<Author> GetAuthors()
        {
            return authorRepository.GetAll();
        }

        public Author GetAuthor(int id)
        {
            return authorRepository.Get(id);
        }

        public void InsertAuthor(Author author)
        {
            authorRepository.Insert(author);
        }

        public void UpdateAuthor(Author author)
        {
            authorRepository.Update(author);
        }

        public void DeleteAuthor(int id)
        {
            Author author = authorRepository.Get(id);
            authorRepository.Delete(author);
        }
    }
}
