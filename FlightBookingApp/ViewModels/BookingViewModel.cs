namespace FlightBookingApp.ViewModels
{
    public class BookingViewModel
    {
        public int FlightId { get; set; }
        public int NumberOfPassengers { get; set; }
        public string SeatType { get; set; }
        public List<string> PassengerName { get; set; }
        public List<int> PassengerAge { get; set; }
        public List<string> PassengerGender { get; set; }
    }
}
