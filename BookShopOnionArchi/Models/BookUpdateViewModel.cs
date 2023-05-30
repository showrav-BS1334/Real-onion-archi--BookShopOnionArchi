using OA.Entity;

namespace BookShopOnionArchi.Models
{
    public class BookUpdateViewModel
    {
        public Book Book { get; set; }
        public List<Author> AuthorList { get; set; }
    }
}
