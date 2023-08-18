using Bookish.Models.Database;
namespace Bookish.Models;


public class MemberViewModel
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public DateTime? DateEnrolled { get; set; }

    public MemberViewModel (int id, string name)
    {
        Id = id;
        Name = name;
    }

    public MemberViewModel (MemberModel dbModel)
    {
        Id = dbModel.Id;
        Name = dbModel.Name;
        Email = dbModel.Email;
        DateEnrolled = dbModel.DateEnrolled;
    }
}
