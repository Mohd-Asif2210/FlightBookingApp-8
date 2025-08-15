using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FlightBookingApp.ApplicationDbContext;
using FlightBookingApp.Models;
using Newtonsoft.Json;
using System.Text;

namespace FlightBookingApp.Controllers
{
    public class FlightsController : Controller
    {
        public async Task<IActionResult> Index()
        {

            List<Flight> FlightList = new List<Flight>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:7143/api/Flight"))
                {
                    string apiresponse = await response.Content.ReadAsStringAsync();
                    FlightList = JsonConvert.DeserializeObject<List<Flight>>(apiresponse);
                }
            }
            return View(FlightList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Flight flight)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(flight), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("http://localhost:7143/api/Flight", content))
                {
                    string apiresponse = await response.Content.ReadAsStringAsync();
                    //studentList = JsonConvert.DeserializeObject<List<Student>>(apiresponse);
                }
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            Flight flight = new Flight();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:7143/api/Flight/" + id))
                {
                    string apiresponse = await response.Content.ReadAsStringAsync();
                    flight = JsonConvert.DeserializeObject<Flight>(apiresponse);
                }
            }

            return View(flight);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Flight flight)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(flight), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PutAsync("http://localhost:7143/api/Flight/" + id, content))
                {
                    string apiresponse = await response.Content.ReadAsStringAsync();
                    //studentList = JsonConvert.DeserializeObject<List<Student>>(apiresponse);
                }
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            Flight flight = new Flight();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:7143/api/Flight" + id))
                {
                    string apiresponse = await response.Content.ReadAsStringAsync();
                    flight = JsonConvert.DeserializeObject<Flight>(apiresponse);
                }
            }

            return View(flight);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Flight fli = new Flight();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:7143/api/Flight/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    fli = JsonConvert.DeserializeObject<Flight>(apiResponse);
                }
            }
            return View(fli);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("http://localhost:7143/api/Flight/" + id))
                {

                }
            }
            return RedirectToAction("Index");
        }
    }
}
