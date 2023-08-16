namespace Bookish.Models;

public class AuthorViewModel
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int? YearOfBirth { get; set; }

    public string? AuthorPhotoUrl { get; set; }

    public string? Bio { get; set; }

    public AuthorViewModel(int id, string name)
    {
        Id = id;
        Name = name;
    }
}
