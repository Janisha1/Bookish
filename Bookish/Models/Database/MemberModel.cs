using Microsoft.EntityFrameworkCore;

namespace Bookish.Models.Database;

public class MemberModel
{
    public int Id {get; set;}
    public string? Name { get; set; }

    public string? Email { get; set; }

    public DateTime DateEnrolled {get; set;}
}
