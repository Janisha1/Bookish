using Bookish.Models.Database;

namespace Bookish.Models;

public class BookViewModel
{
    public string Isbn { get; set; }

    public string Title { get; set; }

    public string? CoverPhotoUrl { get; set; }

    public string? Blurb { get; set; }

    public string? Genre { get; set; }

    public int? YearPublished { get; set; }

    public class BookAuthorViewModel
    {
        public int? Id { get; set; }
        public string? Name { get; set; }

        public BookAuthorViewModel(AuthorModel dbModel){
            Id = dbModel.Id;
            Name = dbModel.Name;
        }
    }


    public List<BookAuthorViewModel>? Authors { get; set; }

    public List<BookCopyViewModel>? Copies { get; set; }

    public BookViewModel(string isbn, string title)
    {
        Isbn = isbn;
        Title = title;
        Authors = new List<BookAuthorViewModel>();
        Copies = new List<BookCopyViewModel>();
    }

    public BookViewModel(BookModel dbModel)
    {
        if (dbModel.Isbn == null 
            || dbModel.Title == null 
            || dbModel.Authors == null
            || dbModel.Copies == null)
        {
            throw new ArgumentException("fields can't be null");
        }
        else
        {
            Isbn = dbModel.Isbn;
            Title = dbModel.Title;
            CoverPhotoUrl = dbModel.CoverPhotoUrl;
            Blurb = dbModel.Blurb;
            Genre = dbModel.Genre;
            YearPublished = dbModel.YearPublished;
            Authors = dbModel.Authors.Select(a => new BookAuthorViewModel(a)).ToList();
            Copies = dbModel.Copies.Select(c => new BookCopyViewModel(c)).ToList();
        }
    }
}
