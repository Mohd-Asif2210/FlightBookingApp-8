using System.ComponentModel.DataAnnotations;

namespace FlightBookingApp.Models

{
    public class Passenger
    {
        [Key]
        public int PassengerId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Gender { get; set; }
        public int BookingId { get; set; }
        public Booking Booking { get; set; }

    }
}
