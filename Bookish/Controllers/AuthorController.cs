using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Bookish.Models;
using Bookish.Repositories;

namespace Bookish.Controllers;

[Route("/Authors")]
public class AuthorController : Controller
{
    private readonly ILogger<AuthorController> _logger;

    private readonly IAuthorRepo _authorRepo;

    public AuthorController(ILogger<AuthorController> logger, IAuthorRepo authorRepo)
    {
        _logger = logger;
        _authorRepo = authorRepo;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        var authors = _authorRepo.GetAllAuthors()
        .Select(a => new AuthorViewModel(a))
        .ToList();
        return View("index", authors);
    }


    [HttpGet("{id}")]
    public IActionResult GetAuthor([FromRoute] int id)
    {
        var author = new AuthorViewModel(_authorRepo.GetAuthorById(id));
        return View("Author", author);
    }
}
