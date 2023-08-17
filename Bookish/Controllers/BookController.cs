using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Bookish.Models;
using Bookish.Repositories;

namespace Bookish.Controllers;

[Route("/Books")]
public class BookController : Controller
{
    private readonly ILogger<BookController> _logger;

    private readonly IBookRepo _bookRepo;

    public BookController(ILogger<BookController> logger, IBookRepo bookRepo)
    {
        _logger = logger;
        _bookRepo = bookRepo;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        var books = _bookRepo.GetAllBooks()
        .Select(b => new BookViewModel(b))
        .ToList();
        return View("index", books);
    }

  
    [HttpGet("{isbn}")]
    public IActionResult GetBook([FromRoute] string isbn)
    {
        var book = new BookViewModel(_bookRepo.GetBookByIsbn(isbn));
        return View("Book", book);
    }
}
