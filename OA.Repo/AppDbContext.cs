using Microsoft.EntityFrameworkCore;
using OA.Entity;

namespace OA.Repo
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        // creating table in DB according to the models
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
