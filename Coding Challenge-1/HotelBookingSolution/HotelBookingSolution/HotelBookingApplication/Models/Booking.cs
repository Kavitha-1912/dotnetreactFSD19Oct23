using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApplication.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public String UserId {  get; set; }
        [ForeignKey("UserId")]
        public User user { get; set; }
        public string Date { get; set; }
        public string CheckIn { get; set; }
        public string CheckOut { get; set; }
        public int RoomId {  get; set; }
        [ForeignKey("RoomId")]
        public Room room { get; set; }
        public int TotalRooms { get; set; }
        public float Price { get; set; }
    }
}
