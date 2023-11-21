using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApplication.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public string RoomType { get; set; }
        public int HotelId { get; set; }
        [ForeignKey("HotelId")]
        public Hotel Hotel { get; set; }
        public int TotalRooms { get; set; }
        public int AvailableRooms { get; set; }
        public float Price { get; set; }

    }
}
