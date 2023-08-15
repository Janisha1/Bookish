namespace Bookish.Models;

public class BookViewModel
{
    public string Isbn { get; set; }

    public string Title { get; set; }

    public string? CoverPhotoUrl { get; set; }

    public string? Blurb { get; set; }

    public string? Genre { get; set; }

    public int? YearPublished { get; set; }

    public BookViewModel(string isbn, string title)
    {
        Isbn = isbn;
        Title = title;
    }
}
