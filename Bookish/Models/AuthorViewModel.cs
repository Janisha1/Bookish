using Bookish.Models.Database;
namespace Bookish.Models;


public class AuthorViewModel
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int? YearOfBirth { get; set; }

    public string? AuthorPhotoUrl { get; set; }

    public string? Bio { get; set; }


    public class AuthorBookViewModel
    {
        public string? Isbn { get; set; }
        public string? Title { get; set; }

        public AuthorBookViewModel(BookModel dbModel)
        {
            Isbn = dbModel.Isbn;
            Title = dbModel.Title;
        }
    }

    public List<AuthorBookViewModel>? Books { get; set; }

    public AuthorViewModel(int id, string name)
    {
        Id = id;
        Name = name;
        Books = new List<AuthorBookViewModel>();
    }

    public AuthorViewModel(AuthorModel dbModel)
    {

        if (dbModel.Id == 0 || dbModel.Name == null || dbModel.Books == null)
        {
            throw new ArgumentNullException(nameof(dbModel.Id));
        }
        else
        {
        Id = dbModel.Id;
        Name = dbModel.Name;
        YearOfBirth = dbModel.YearOfBirth;
        AuthorPhotoUrl = dbModel.AuthorPhotoUrl;
        Bio = dbModel.Bio;
        Books = dbModel.Books.Select(b => new AuthorBookViewModel(b)).ToList();
        }
    }
}
