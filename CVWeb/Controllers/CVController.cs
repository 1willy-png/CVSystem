using Microsoft.AspNetCore.Mvc;
using CVSystem.Data;
using CVSystem.Models;

namespace CVSystem.Controllers
{
    public class CVController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CVController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CV cv)
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            cv.UserId = userId.Value;

            _context.CVs.Add(cv);
            _context.SaveChanges();

            return RedirectToAction("Dashboard", "Account");
        }
    }
}