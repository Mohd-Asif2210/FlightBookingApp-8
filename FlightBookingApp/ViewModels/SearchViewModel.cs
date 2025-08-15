namespace FlightBookingApp.ViewModels
{
    public class SearchViewModel
    {
        public List<string> FromCities { get; set; }
        public List<string> ToCities { get; set; }

        public List<DateTime> Dates { get; set; }
    }
}
