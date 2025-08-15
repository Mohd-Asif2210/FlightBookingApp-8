using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FlightBookingApp.ApplicationDbContext;
using FlightBookingApp.Models;

namespace FlightBookingApp.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AdminLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Check if username and password match
                if (model.Username == "asif@jxtravels.com" && model.Password == "Admin@123")
                {
                    // Redirect to Admin/Index on successful login
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Index()
        {
            // Your admin index logic here
            return View();
        }
    }

}
