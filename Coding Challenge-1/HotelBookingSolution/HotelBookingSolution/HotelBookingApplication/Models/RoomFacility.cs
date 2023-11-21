using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApplication.Models
{
    public class RoomFacility
    {
        public int RoomFacilityId { get; set; }
        public int RoomId { get; set; }
        [ForeignKey("RoomId")]
        public Room Room{ get; set; }
        public string Facilities { get; set; }
    }
}
