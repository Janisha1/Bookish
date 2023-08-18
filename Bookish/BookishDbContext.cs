using Bookish.Models;
using Bookish.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace Bookish
{
    public class BookishDbContext : DbContext
    {
        // Put all the tables you want in your database here
        public DbSet<AuthorModel> Authors { get; set; }
        public DbSet<BookModel> Books { get; set; }
        public DbSet<BookCopyModel> BookCopies { get; set; }
        public DbSet<MemberModel> Members { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // This is the configuration used for connecting to the database
            optionsBuilder.UseNpgsql(@"Server=localhost;Port=5432;Database=bookish;User Id=bookish;Password=bookish;");
        }
    }
}