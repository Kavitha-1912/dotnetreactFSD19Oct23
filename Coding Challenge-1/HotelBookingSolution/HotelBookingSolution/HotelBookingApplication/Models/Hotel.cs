using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelBookingApplication.Models
{
    public class Hotel
    {
        [Key]
        public int HotelId { get; set; }

        public string HotelName { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public User user { get; set; }
        public string Location { get; set; }
        public string Address {  get; set; }
        
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
    }
}
