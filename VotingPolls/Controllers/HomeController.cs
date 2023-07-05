using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VotingPolls.Models;

namespace VotingPolls.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            TempData.Clear();
            return View();
        }

        public IActionResult NotImplemented()
        {
            TempData.Clear();
            return View();
        }

        public IActionResult NotAuthorized()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            TempData.Clear();
            return View();
        }

        public IActionResult Bonus()
        {
            TempData.Clear();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(string errorValue)
        {
            if (errorValue != null)
            {
                ViewBag.errorValue = errorValue;
            }
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}