using FlightBookAPI.DBContext;
using FlightBookAPI.Models;
 
namespace FlightBookAPI.Services
{
    public class FlightService : IFlightRepository
    {
        private readonly AppDBContext _dbContext;
 
        public FlightService(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }
 
        public IEnumerable<Flight> GetAllFlights()
        {
            var flights = _dbContext.Flights;
            return flights;
        }
        public Flight GetFlightById(int id)
        {
            return _dbContext.Flights.FirstOrDefault(a => a.FlightId == id);
        }
        public Flight AddFlight(Flight flight)
        {
            _dbContext.Flights.Add(flight);
            _dbContext.SaveChanges();
            return flight;
        }
        public Flight UpdateFlight(int id, Flight flight)
        {
            var existingflight = _dbContext.Flights.Find(id);
 
            //if (existingflight == null)
            //{
            //    return NotFound();
            //}
 
            existingflight.AirLine = flight.AirLine;
            existingflight.From = flight.From;
            existingflight.To = flight.To;
            existingflight.EconomySeats = flight.EconomySeats;
            existingflight.BusinessSeats = flight.BusinessSeats;
            existingflight.EconomyPrice = flight.EconomyPrice;
            existingflight.BusinessPrice = flight.BusinessPrice;
            existingflight.DepartureDate = flight.DepartureDate;
            existingflight.DepartureTime = flight.DepartureTime;
            existingflight.AvailableBusinessSeats = flight.AvailableBusinessSeats;
            existingflight.AvailableEconomySeats = flight.AvailableEconomySeats;
            existingflight.NoOfStops = flight.NoOfStops;
            existingflight.ArrivalDate = flight.ArrivalDate;
            existingflight.IsMultiCity = flight.IsMultiCity;
            existingflight.IsRoundTrip = flight.IsRoundTrip;
            _dbContext.SaveChanges();
 
            return flight;
        }
        public void DeleteFlight(int id)
        {
            var FlightsToDelete = _dbContext.Flights.FirstOrDefault(a => a.FlightId == id);
            _dbContext.Flights.Remove(FlightsToDelete);
            _dbContext.SaveChanges();
 
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
 