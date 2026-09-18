using BloodBankManagementSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace BloodBankManagementSystem.Controllers
{
    [Authorize(Roles = "Admin,Staff")]
    public class HomeController : Controller
    {
        private readonly BloodBankDbContext _context;

        public HomeController(BloodBankDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.TotalDonors = _context.Donors.Count();
            ViewBag.TotalBloodStock = _context.BloodStocks.Sum(x => x.UnitsAvailable);
            ViewBag.TotalRequests = _context.BloodRequests.Count();

            return View();
        }
    }
}