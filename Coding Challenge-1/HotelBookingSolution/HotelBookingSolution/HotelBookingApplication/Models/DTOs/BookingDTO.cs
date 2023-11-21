namespace HotelBookingApplication.Models.DTOs
{
    public class BookingDTO
    {
        public string UserId {  get; set; }
        public string CheckIn {  get; set; }
        public string CheckOut { get; set; }
        public int RoomId {  get; set; }
        public int TotalRooms {  get; set; }
    }
}
