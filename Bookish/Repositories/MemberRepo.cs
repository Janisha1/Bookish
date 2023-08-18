using Bookish.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace Bookish.Repositories;


public interface IMemberRepo
{
    List<MemberModel> GetAllMembers();
    MemberModel GetMemberById(int id);
}
public class MemberRepo: IMemberRepo
{
    private readonly BookishDbContext _context;

    public MemberRepo(BookishDbContext context)
    {
        _context = context;
    }

    public List<MemberModel> GetAllMembers()
    {
        return _context.Members.ToList();
    }

    public MemberModel GetMemberById(int id)
    {
        return _context.Members
        .Where(a => a.Id == id)
        .Single();
    }
}