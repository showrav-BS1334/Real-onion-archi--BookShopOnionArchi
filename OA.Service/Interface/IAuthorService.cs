using OA.Entity;

namespace OA.Service.Interface
{
    public interface IAuthorService
    {
        IEnumerable<Author> GetAuthors();
        Author GetAuthor(int id);
        void InsertAuthor(Author author);
        void UpdateAuthor(Author author);
        void DeleteAuthor(int id);
    }
}
