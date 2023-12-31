using Bookish.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace Bookish.Repositories;


public interface IBookRepo
{
    List<BookModel> GetAllBooks();
    BookModel GetBookByIsbn(string isbn);
}

public class BookRepo : IBookRepo
{
    private readonly BookishDbContext _context;

    public BookRepo(BookishDbContext context)
    {
        _context = context;
    }

    public List<BookModel> GetAllBooks()
    {
        return _context.Books
        .Include(b => b.Authors)
        .Include(b =>b.Copies)
        .ToList();
    }

    public BookModel GetBookByIsbn(string isbn)
    {
        return _context.Books
        .Include(b => b.Authors)
        .Include(b =>b.Copies)
        .Where(b => b.Isbn == isbn)
        .Single();
    }
}