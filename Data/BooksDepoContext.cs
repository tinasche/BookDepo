using BookDepo.Models;
using Microsoft.EntityFrameworkCore;

namespace BookDepo.Data
{
    public class BooksDepoContext : DbContext
    {
        public BooksDepoContext(DbContextOptions<BooksDepoContext> opt) : base(opt){ }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

    }
}