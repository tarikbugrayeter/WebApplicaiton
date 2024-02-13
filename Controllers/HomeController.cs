using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApplicationProject.Models;

namespace WebApplicationProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly WebDatabaseContext _context;

        public HomeController(WebDatabaseContext context,ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        

        [HttpPost]
        public IActionResult Login(AdminLogin user)
        {
            var userInDb = _context.AdminLogins.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);

            if (userInDb != null)
            {
                // Ba�ar�l� giri�, y�nlendirme yap�labilir
                return Redirect("~/Dashboard");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Ge�ersiz kullan�c� ad� veya parola.");
                return View("Index",user);
            }
        }

    }
}
