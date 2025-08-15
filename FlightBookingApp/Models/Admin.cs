using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FlightBookingApp.Models
{
    [Table("TblAdmin")]
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        [Required(ErrorMessage = "User Name Required")]
        [MinLength(3, ErrorMessage = "Minimum 6 characters Required"), MaxLength(10, ErrorMessage = "Maximum 30 characters Required")]
        [Display(Name = "User Name")]
        public string AName { get; set; }

        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Minimum 6 characters Required"), MaxLength(10, ErrorMessage = "Maximum 10 characters Required")]
        public string Password { get; set; }
    }
}
