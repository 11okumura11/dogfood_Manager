using food_manager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace food_manager.Controllers
{
    [Authorize]
    public class FoodManagerController : Controller
    {
        private readonly ILogger<FoodManagerController> _logger;

        public FoodManagerController(ILogger<FoodManagerController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
           ViewBag.SessionName = HttpContext.Session.GetString("Name");

            return View();
        }
        public IActionResult Register()
        {
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