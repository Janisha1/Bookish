using Bookish.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace Bookish.Repositories;


public interface IAuthorRepo
{
    List<AuthorModel> GetAllAuthors();
    AuthorModel GetAuthorById(int id);
}
public class AuthorRepo: IAuthorRepo
{
    private readonly BookishDbContext _context;

    public AuthorRepo(BookishDbContext context)
    {
        _context = context;
    }

    public List<AuthorModel> GetAllAuthors()
    {
        return _context.Authors
        .Include(a => a.Books)
        .ToList();
    }

    public AuthorModel GetAuthorById(int id)
    {
        return _context.Authors
        .Where(a => a.Id == id)
        .Single();
    }
}