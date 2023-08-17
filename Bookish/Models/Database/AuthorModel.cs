namespace Bookish.Models.Database;

public class AuthorModel
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? YearOfBirth { get; set; }

    public string? AuthorPhotoUrl { get; set; }

    public string? Bio { get; set; }

    public List<BookModel>? Books { get; set; }
}
