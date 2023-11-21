using HotelBookingApplication.Exceptions;
using HotelBookingApplication.Interfaces;
using HotelBookingApplication.Models;
using HotelBookingApplication.Models.DTOs;
using HotelBookingApplication.Repositories;
using System.Net.Mail;
using System.Net;

namespace HotelBookingApplication.Services
{
    public class BookingService : IBookingService
    {
        private readonly IRepository<int, Booking> _bookingRepository;
        private readonly IRepository<int, Room> _roomRepository;
        private readonly IRepository<int, Hotel> _hotelRepository;
        private readonly IRepository<string, User> _userRepository;

        public BookingService(IRepository<int, Booking> bookingRepository, IRepository<int, Room> roomRepository, IRepository<int, Hotel> hotelRepository, IRepository<string, User> userRepository)
        {
            _bookingRepository = bookingRepository;
            _roomRepository = roomRepository;
            _hotelRepository = hotelRepository;
            _userRepository = userRepository;
        }

        public BookingDTO AddBookingDetails(BookingDTO bookingDTO)
        {

            int roomId = bookingDTO.RoomId;
            var room = _roomRepository.GetById(roomId);
            var hotel = _hotelRepository.GetById(room.HotelId);

            float amount = (bookingDTO.TotalRooms * room.Price);
            DateTime dateTime = DateTime.Now;

            Booking booking = new Booking()
            {
                UserId = bookingDTO.UserId,
                CheckIn = bookingDTO.CheckIn,
                CheckOut = bookingDTO.CheckOut,
                RoomId = bookingDTO.RoomId,
                TotalRooms = bookingDTO.TotalRooms,
                Date = dateTime.ToString(),
                Price = amount

            };
            var result = _bookingRepository.Add(booking);
            var user = _userRepository.GetById(bookingDTO.UserId);
            string message = $"Dear {user.Name},\nThank you for choosing {hotel.HotelName}! Your reservation is confirmed, Your booking reference number is {result.BookingId}. \nSafe travels!\nBest regards,\nThe {hotel.HotelName} Team\n{hotel.PhoneNumber}";
            string subject = $"Booking Confirmation - {hotel.HotelName}";
            string body = $"Dear {user.Name},\nThank you for choosing {hotel.HotelName}! Your reservation is confirmed, \nBooking Details:-\nBooking ID: {result.BookingId}\nCheck-In Date: {result.CheckIn}\nCheck-Out Date: {result.CheckOut}\nRoom Type: {room.RoomType}\nTotal Price: {amount}\n\nWe look forward to making your stay at {hotel.HotelName} a memorable experience. Safe travels!\nBest regards,\nThe {hotel.HotelName} Team\n{hotel.PhoneNumber}";

            if (result != null)
            {
                return bookingDTO;
            }
            return null;
        }

        public List<Booking> GetBooking(int hotelId)
        {
            var bookings = (from Booking in _bookingRepository.GetAll()
                            join room in _roomRepository.GetAll() on Booking.RoomId equals room.RoomId
                            where room.HotelId == hotelId
                            select new Booking
                            {
                                BookingId = Booking.BookingId,
                                Date = Booking.Date,
                                CheckIn = Booking.CheckIn,
                                CheckOut = Booking.CheckOut,
                                RoomId = Booking.RoomId,
                                TotalRooms = Booking.TotalRooms,
                                Price = Booking.Price,
                                UserId = Booking.UserId
                            })
                    .ToList();

            if (bookings.Count > 0)
            {
                return bookings;
            }
            return null;
        }

        public List<Booking> GetUserBooking(string userId)
        {
            var user = _bookingRepository.GetAll().Where(u => u.UserId == userId).ToList();

            if (user != null)
            {
                return user;
            }
            throw new NoBookingsAvailableException();
        }
        public Booking UpdateBookingStatus(int bookingId, string status)
        {
            var booking = _bookingRepository.GetById(bookingId);
            if (booking != null)
            {
                var result = _bookingRepository.Update(booking);
                return booking;
            }
            return null;
        }
       
    }
}