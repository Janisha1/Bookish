using Bookish.Models.Database;

namespace Bookish.Models;

public class BookCopyViewModel
{
    public string Barcode { get; set; }
    public class BookCopyBookViewModel
    {
        public string? Isbn { get; set; }
        public string? Title { get; set; }

        public BookCopyBookViewModel(string isbn, string title)
        {
            Isbn = isbn;
            Title = title;
        }

    }
    public BookCopyBookViewModel? Book { get; set; }


    public BookCopyViewModel(BookCopyModel dbModel)
    {
        if (dbModel.Barcode == null 
            || dbModel.Book == null
            || dbModel.Book.Isbn == null
            || dbModel.Book.Title == null
            )
        {
            throw new ArgumentException("fields can't be null");
        }
        else
        {
            Barcode = dbModel.Barcode;
            Book = new BookCopyBookViewModel(dbModel.Book.Isbn, dbModel.Book.Title);
        }
    }
}




