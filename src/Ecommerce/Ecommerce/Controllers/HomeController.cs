using System.Diagnostics;
using BeautyStore.Application.User;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserSession _userSession;

        public HomeController(ILogger<HomeController> logger, IUserSession userSession)
        {
            _logger = logger;
            _userSession = userSession;
        }

        public IActionResult Index()
        {
            var user = _userSession.GetSession();

            if (user != null && user.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Dashboard");
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
