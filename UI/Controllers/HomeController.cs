using Frontend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using UI.DB;
using UI.Models;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        public readonly ApplicationDBContext _context;
        public readonly UserManager<User> _userManager;

        public HomeController(UI.DB.ApplicationDBContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser != null)
            {
                if (User.Identity.IsAuthenticated)
                {
                    ViewBag.CurrentUserName = currentUser.UserName;
                }
                var messages = await _context.Messages.OrderByDescending(m => m.When).Take(50).ToListAsync();
                return View(messages);
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
