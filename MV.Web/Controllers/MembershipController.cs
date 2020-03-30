using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MV.Web.Data;

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

    public async Task<IActionResult> Index()
    {
      return View(await _context.Memberships.ToListAsync());
    }

    public async Task<IActionResult> Details(int? Id)
    {
      var membership = await _context.Memberships.Include(me => me.Members).FirstOrDefaultAsync(mem => mem.ID == Id);
      return View(membership);
    }
  }
}
