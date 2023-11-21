namespace HotelBookingApplication.Models.DTOs
{
    public class RoomDTO
    {
        public string RoomType { get; set; }
        public string HotelId { get; set;}
        public float Price { get; set;}
        public int Capacity { get; set;}
        public int TotalRooms {  get; set;}
        public string Desription {  get; set;}
        public List<string> RoomFacilities {  get; set;}

    }
}
