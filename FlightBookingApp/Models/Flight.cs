using System.ComponentModel.DataAnnotations;

namespace FlightBookingApp.Models

{
    public class Flight
    {
        [Key]
        public int FlightId { get; set; }

        [Required(ErrorMessage = "AirLine Required")]
        [MinLength(6, ErrorMessage = "Minimum 5 characters Required"), MaxLength(10, ErrorMessage = "Maximum 15 characters Required")]
        [Display(Name = "AirLine")]
        public string AirLine { get; set; }


        [Required(ErrorMessage = "Capacity Required")]
        [Range(50, 200, ErrorMessage = "Enter in range of 50-200")]
        [Display(Name = "Economy Seats")]
        public int EconomySeats { get; set; }


        [Required(ErrorMessage = "Capacity Required")]
        [Range(50, 200, ErrorMessage = "Enter in range of 50-200")]
        [Display(Name = "Business Seats")]
        public int BusinessSeats { get; set; }


        [Required(ErrorMessage = "Price Required")]
        //[Range(50, 200, ErrorMessage = "Minimum 18 years of Age is required")]
        [Display(Name = "Economy Fare")]
        public float EconomyPrice { get; set; }


        [Required(ErrorMessage = "Price Required")]
        //[Range(50, 200, ErrorMessage = "Minimum 18 years of Age is required")]
        [Display(Name = "Business Fare")]
        public float BusinessPrice { get; set; }


        [Required(ErrorMessage = "Departure Location Required")]
        [Display(Name = "From City")]
        //[MinLength(6, ErrorMessage = "Minimum 6 characters Required"), MaxLength(10, ErrorMessage = "Maximum 10 characters Required")]
        public string From { get; set; }


        [Required(ErrorMessage = "Destination Location Required")]
        [Display(Name = "To City")]
        //[MinLength(6, ErrorMessage = "Minimum 6 characters Required"), MaxLength(10, ErrorMessage = "Maximum 10 characters Required")]
        public string To { get; set; }


        [Required(ErrorMessage = "Departure Date Required")]
        [DataType(DataType.Date)]
        [Display(Name = "Departure Date")]
        public DateTime DepartureDate { get; set; }


        [Required(ErrorMessage = "Departure Time Required")]
        [DataType(DataType.Time)]
        [Display(Name = "Departure time")]
        public DateTime DepartureTime { get; set; }


        //---------------------------------//
        [Required]
        [Display(Name = "No. of Stops")]
        public int NoOfStops { get; set; }
        [Required]
        [Display(Name = "Available Economy Seats")]


        public int AvailableEconomySeats { get; set; }
        [Required]
        [Display(Name = "Available Business Seats")]

        public int AvailableBusinessSeats { get; set; }


        public bool? IsRoundTrip { get; set; }
        [Display(Name = "Round Trip")]


        public bool? IsMultiCity { get; set; }
        [Display(Name = "Multi City")]

        public DateTime? ArrivalDate { get; set; }

        //public virtual Passenger Passenger { get; set; }
        //public ICollection<Booking> Bookings { get; set; }
    }
}