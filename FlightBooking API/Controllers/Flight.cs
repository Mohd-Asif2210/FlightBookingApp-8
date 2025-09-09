using FlightBookAPI.Models;
using FlightBookAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace FlightBookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IFlightRepository FlightService;
        public FlightController(IFlightRepository _FlightService)
        {
            FlightService = _FlightService;
        }
 
        [HttpGet]
        public IEnumerable<Flight> GetAllFlights()
        {
            var flights = FlightService.GetAllFlights();
            return flights;
        }
        [HttpGet("{id}")]
        public Flight GetFlightById(int id)
        {
            return FlightService.GetFlightById(id);
        }
 
        [HttpPost]
        public Flight AddFlight([FromBody] Flight flight)
        {
            return FlightService.AddFlight(flight);
        }
 
        [HttpPut("{id}")]
        public Flight UpdateFlight(int id, [FromBody] Flight flight)
        {
            return FlightService.UpdateFlight(id, flight);
        }
 
        [HttpDelete("{id}")]
        public void DeleteFlight(int id)
        {
            FlightService.DeleteFlight(id);
        }
    }
}