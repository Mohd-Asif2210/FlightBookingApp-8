using System.ComponentModel.DataAnnotations;

namespace FlightBookingApp.Models;


public class AdminLoginViewModel
{
    [Required(ErrorMessage = "Username is required.")]
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
