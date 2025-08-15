using FlightBookingApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FlightBookingApp.Controllers
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
            return View();
        }
 
        public IActionResult FAQ()
        {
            return View();
        }
        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        
        public IActionResult Offers()
        {
            return View();
        }
        public IActionResult Contactus()
        {
            return View();
        }

        public IActionResult Careers()
        {
            return View();
        }
        public IActionResult Agreement()
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
