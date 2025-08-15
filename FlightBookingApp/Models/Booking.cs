using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FlightBookingApp.Models
{
    [Table("TblFlightBook")]
    public class Booking
    {
        [Key]
        public int bId { get; set; }

        [Required]
        [ForeignKey("Flight")]
        public int FlightId { get; set; }
        public virtual Flight Flight { get; set; }

        
        public int NumberOfPassengers { get; set; }

        [Display(Name = "Seat Type")]
        [StringLength(25)]
        public string SeatType { get; set; }

        public float TotalAmount { get; set; }

        //   public string UserID { get; set; }

        public string UserId { get; set; }

        public ICollection<Passenger> Passengers { get; set; }

        



    }
}
