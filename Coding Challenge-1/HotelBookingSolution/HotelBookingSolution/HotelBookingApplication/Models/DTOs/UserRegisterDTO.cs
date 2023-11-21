using System.ComponentModel.DataAnnotations;

namespace HotelBookingApplication.Models.DTOs
{
    public class UserRegisterDTO
    {
        [Required(ErrorMessage = "Email cannot be empty")]
        public string Email { get; set; }
        public string Password { get; set; }
        [Required (ErrorMessage ="Retype Password Cannot be Empty")]
        [Compare("Password",ErrorMessage ="Password and Retyped password does not match")]
        public string ReTypePassword {  get; set; }
        [Required(ErrorMessage ="Name cannot be empty")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Phone number cannot be empty")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage ="Address cannot be empty")]
        public string Address { get; set; }
        public object Token { get; internal set; }
    }
}
