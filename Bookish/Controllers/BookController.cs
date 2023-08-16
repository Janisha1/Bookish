using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Bookish.Models;

namespace Bookish.Controllers;

[Route("/Books")]
public class BookController : Controller
{
    private readonly ILogger<BookController> _logger;

    public BookController(ILogger<BookController> logger)
    {
        _logger = logger;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        var books = new List<BookViewModel>
        {
            new BookViewModel(
                 "9780330508117"
                ,"The Hitchhiker's Guide to the Galaxy"
            ){
                CoverPhotoUrl = "https://assets-eu-01.kc-usercontent.com/bcd02f72-b50c-0179-8b4b-5e44f5340bd4/2b788053-b036-430c-8503-10437ff03616/hitchhikers-guide-to-the-galaxy-original-cover.jpg?w=200&h=350&auto=format&bg=%23efefef&fit=crop"
                ,Blurb = "It's an ordinary Thursday lunchtime for Arthur Dent until his house gets demolished. The Earth follows shortly afterwards to make way for a new hyperspace express route, and his best friend has just announced that he's an alien."
                ,Genre = "comedy science fiction"
                ,YearPublished = 1979
                ,Authors = new List<AuthorViewModel>(){}
                ,Copies = new List<BookCopyViewModel>(){}
            },
        new BookViewModel(
                "9780330508117"
                ,"The Hitchhiker's Guide to the Galaxy - ed 2"
            ){
                CoverPhotoUrl = "https://assets-eu-01.kc-usercontent.com/bcd02f72-b50c-0179-8b4b-5e44f5340bd4/2b788053-b036-430c-8503-10437ff03616/hitchhikers-guide-to-the-galaxy-original-cover.jpg?w=200&h=350&auto=format&bg=%23efefef&fit=crop"
                ,Blurb = "It's an ordinary Thursday lunchtime for Arthur Dent until his house gets demolished. The Earth follows shortly afterwards to make way for a new hyperspace express route, and his best friend has just announced that he's an alien."
                ,Genre = "comedy science fiction"
                ,YearPublished = 1979
                ,Authors = new List<AuthorViewModel>(){}
                ,Copies = new List<BookCopyViewModel>(){}
            }
        };

        return View("index", books);
    }

    // [Route("/Books")]
    [HttpGet("book")]
    public IActionResult GetBook()
    {
        var book = new BookViewModel(
             "9780330508117"
            , "The Hitchhiker's Guide to the Galaxy"
        )
        {
            CoverPhotoUrl = "https://assets-eu-01.kc-usercontent.com/bcd02f72-b50c-0179-8b4b-5e44f5340bd4/2b788053-b036-430c-8503-10437ff03616/hitchhikers-guide-to-the-galaxy-original-cover.jpg?w=200&h=350&auto=format&bg=%23efefef&fit=crop"
            ,
            Blurb = "It's an ordinary Thursday lunchtime for Arthur Dent until his house gets demolished. The Earth follows shortly afterwards to make way for a new hyperspace express route, and his best friend has just announced that he's an alien."
            ,
            Genre = "comedy science fiction"
            ,
            YearPublished = 1979
            ,
            Authors = new List<AuthorViewModel>() { }
            ,
            Copies = new List<BookCopyViewModel>() { }
        };
        return View("Book", book);
    }
}
