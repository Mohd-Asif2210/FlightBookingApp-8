using FlightBookingApp.ApplicationDbContext;
using FlightBookingApp.Models;
using FlightBookingApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace FlightBookingApp.Controllers
{
    public class BookingController : Controller
    {
        private readonly AppDbContext _context;

        public BookingController(AppDbContext context)
        {
            _context = context;
        }

        public ActionResult SearchForm()
        {
            ViewBag.FromCities = new SelectList(_context.flights.Select(f => f.From).Distinct());
            ViewBag.ToCities = new SelectList(_context.flights.Select(f => f.To).Distinct());

            return View();
        }

        // Search flights with filtering options
        public ActionResult SearchFlights(string fromCity, string toCity, DateTime departureDate, bool isRoundTrip = false, bool isMultiCity = false)
        {
            var flights = _context.flights.Where(f => f.DepartureDate.Date == departureDate.Date);

            if (!string.IsNullOrEmpty(fromCity))
            {
                flights = flights.Where(f => f.From == fromCity);
            }

            if (!string.IsNullOrEmpty(toCity))
            {
                flights = flights.Where(f => f.To == toCity);
            }

            if (isRoundTrip)
            {
                flights = flights.Where(f => f.IsRoundTrip == true);
            }

            if (isMultiCity)
            {
                flights = flights.Where(f => f.IsMultiCity == true);
            }

            return View("AvailableFlights", flights.ToList());
        }

        [HttpGet]
        public IActionResult AvailableFlights(string fromCity, string toCity, DateTime date)
        {
            var flights = _context.flights
                .Where(f => f.From == fromCity && f.To == toCity && f.DepartureDate.Date == date.Date)
                .ToList();

            return View(flights);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Book(int flightId)
        {
            var viewModel = new BookingViewModel { FlightId = flightId };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Book(int flightId, BookingViewModel model)
        {
            var flight = _context.flights.FirstOrDefault(f => f.FlightId == flightId);
            if (flight == null)
            {
                // Handle invalid flight ID
                return RedirectToAction("Index", "Home");
            }

            // Check if there are enough available seats
            if (model.SeatType == "Economy" && flight.AvailableEconomySeats < model.NumberOfPassengers)
            {
                // Handle insufficient available seats for economy class
                ModelState.AddModelError(string.Empty, "Insufficient available economy seats.");
                return View(model);
            }
            else if (model.SeatType == "Business" && flight.AvailableBusinessSeats < model.NumberOfPassengers)
            {
                // Handle insufficient available seats for business class
                ModelState.AddModelError(string.Empty, "Insufficient available business seats.");
                return View(model);
            }

            // Proceed with booking
            var booking = new Booking
            {
                FlightId = flightId,
                SeatType = model.SeatType,
                NumberOfPassengers = model.NumberOfPassengers,
                TotalAmount = model.NumberOfPassengers * (model.SeatType == "Economy" ? flight.EconomyPrice : flight.BusinessPrice),
                UserId = User.Identity.Name
                //UserId = 1 // Change this to the actual user ID once you have authentication implemented
            };

            // Create passengers and assign to booking
            booking.Passengers = new List<Passenger>();
            for (int i = 0; i < model.NumberOfPassengers; i++)
            {
                var passenger = new Passenger
                {
                    Name = model.PassengerName[i],
                    Age = model.PassengerAge[i],
                    Gender = model.PassengerGender[i]
                };

                _context.Passengers.Add(passenger);
                booking.Passengers.Add(passenger);
            }

            _context.bookings.Add(booking);
            _context.SaveChanges();

            // Update available seats
            if (model.SeatType == "Economy")
            {
                flight.AvailableEconomySeats -= model.NumberOfPassengers;
            }
            else if (model.SeatType == "Business")
            {
                flight.AvailableBusinessSeats -= model.NumberOfPassengers;
            }

            _context.SaveChanges();
            float totalAmount = model.NumberOfPassengers * (model.SeatType == "Economy" ? flight.EconomyPrice : flight.BusinessPrice);
            TempData["TotalAmount"] = totalAmount.ToString();
            return RedirectToAction("Payment");
        }

        public IActionResult Payment()
        {
            try
            {
                // Retrieve the total amount from TempData
                if (TempData.ContainsKey("TotalAmount") && TempData["TotalAmount"] is string totalAmountString)
                {
                    if (float.TryParse(totalAmountString, out float totalAmount))
                    {
                        // Pass the total amount to the payment view
                        ViewData["TotalAmount"] = totalAmount;

                        // Render the payment view
                        return View();
                    }
                    else
                    {
                        // Handle parsing error
                        TempData["ErrorMessage"] = "Error: Total amount could not be parsed.";
                        return RedirectToAction("Error", "Home"); // Redirect to an error page
                    }
                }
                else
                {
                    // Handle missing or invalid total amount in TempData
                    TempData["ErrorMessage"] = "Error: Total amount not found or invalid.";
                    return RedirectToAction("Error", "Home"); // Redirect to an error page
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                TempData["ErrorMessage"] = "Error: An unexpected error occurred.";
                return RedirectToAction("Error", "Home"); // Redirect to an error page
            }
        }
        public ActionResult PaymentConfirmation()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Cancel(int bookingId)
        {
            // Get the booking to cancel
            var booking = _context.bookings
                .Include(b => b.Passengers)
                .FirstOrDefault(b => b.bId == bookingId);

            if (booking == null)
            {
                return NotFound();
            }

            // Remove passengers associated with the booking
            _context.Passengers.RemoveRange(booking.Passengers);

            // Remove the booking itself
            _context.bookings.Remove(booking);

            _context.SaveChanges();

            return RedirectToAction("CancellationConfirmation");
        }

        // GET: Booking/CancellationConfirmation
        public IActionResult CancellationConfirmation()
        {
            return View();
        }

        [Authorize]
        public IActionResult BookingHistory()
        {
            // Retrieve booking history for the current user
            string userId = User.Identity.Name;
            var bookings = _context.bookings
                .Include(b => b.Passengers)
                .Include(b => b.Flight)
                .Where(b => b.UserId == userId)
                .ToList();

            return View(bookings);
        }

        public IActionResult PrintTicket(int bookingId)
        {
            var booking = _context.bookings
                .Include(b => b.Passengers)
                .Include(b => b.Flight)
                .FirstOrDefault(b => b.bId == bookingId);

            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

    }
}
