using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Bookish.Models;
using Bookish.Repositories;

namespace Bookish.Controllers;

[Route("/Members")]
public class MemberController : Controller
{
    private readonly ILogger<MemberController> _logger;

    private readonly IMemberRepo _memberRepo;

    public MemberController(ILogger<MemberController> logger, IMemberRepo memberRepo)
    {
        _logger = logger;
        _memberRepo = memberRepo;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        var members = _memberRepo.GetAllMembers()
        .Select(a => new MemberViewModel(a))
        .ToList();
        return View("index", members);
    }


    [HttpGet("{id}")]
    public IActionResult GetMember([FromRoute] int id)
    {
        var member = new MemberViewModel(_memberRepo.GetMemberById(id));
        return View("Member", member);
    }
}
