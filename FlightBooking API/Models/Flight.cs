namespace FlightBookAPI.Models
{
    public class Flight
    {
        public int FlightId { get; set; }
 
        public string AirLine { get; set; }
 
        public int EconomySeats { get; set; }
 
        public int BusinessSeats { get; set; }
 
        public float EconomyPrice { get; set; }
 
        public float BusinessPrice { get; set; }
 
        public string From { get; set; }
 
        public string To { get; set; }
 
        public DateTime DepartureDate { get; set; }
 
        public DateTime DepartureTime { get; set; }
 
        public int NoOfStops { get; set; }
 
        public int AvailableEconomySeats { get; set; }
 
        public int AvailableBusinessSeats { get; set; }
 
        public bool? IsRoundTrip { get; set; }
 
        public bool? IsMultiCity { get; set; }
 
        public DateTime? ArrivalDate { get; set; }
    }
}