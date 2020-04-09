using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MV.Web.Data;
using MV.Web.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MV.Web.Controllers
{
  public class MembershipController : Controller
  {

    private readonly ILogger<HomeController> _logger;
    private readonly MembershipsContext _context;

    public MembershipController(ILogger<HomeController> logger, MembershipsContext membershipsContext)
    {
      _logger = logger;
      _context = membershipsContext;
    }

    public IActionResult Index()
    {
      var members = _context.Memberships.ToList();
      return View(members);
    }

    public async Task<IActionResult> Details(int? Id)
    {
      var membership = await _context.Memberships.Include(me => me.Members).FirstOrDefaultAsync(mem => mem.ID == Id);
      return View(membership);
    }

    [HttpGet]
    public IActionResult Create()
    {
      var membership = new Membership()
      {
        Members = new List<Person> { new Person() },
        CreationDate = DateTime.Now
      };

      ViewBag.MembershipTypeList = GetMembershipTypeSelectList();

      return View(membership);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Membership membership)
    {
      if (ModelState.IsValid)
      {

        await _context.Memberships.AddAsync(membership);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
      }

      ViewBag.MembershipTypeList = GetMembershipTypeSelectList();
      return View(membership);
    }




    private IEnumerable<SelectListItem> GetMembershipTypeSelectList()
    {
      return new SelectList(_context.MembershipTypes, "ID", "Name");
    }

  }
}
