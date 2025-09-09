using FlightBookAPI.Models;
using Microsoft.AspNetCore.Mvc;
 
namespace FlightBookAPI.Services
{
    public interface IFlightRepository
    {
        public IEnumerable<Flight> GetAllFlights();
        public Flight GetFlightById(int id);
        public Flight AddFlight([FromBody] Flight flight);
        public Flight UpdateFlight(int id, [FromBody] Flight flight);
        public void DeleteFlight(int id);
    }
}