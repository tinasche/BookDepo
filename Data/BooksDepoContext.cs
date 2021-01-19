using BookDepo.Models;
using Microsoft.EntityFrameworkCore;

namespace BookDepo.Data
{
    public class BooksDepoContext : DbContext
    {
        public BooksDepoContext(DbContextOptions<BooksDepoContext> opt) : base(opt){ }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Patron> Patrons { get; set; }

    }
}