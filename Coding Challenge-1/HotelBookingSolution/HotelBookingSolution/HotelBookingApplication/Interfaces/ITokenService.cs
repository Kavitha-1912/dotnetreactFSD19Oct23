using HotelBookingApplication.Models.DTOs;

namespace HotelBookingApplication.Interfaces
{
    public interface ITokenService
    {
        string GetToken(UserDTO user);
        object GetToken(UserRegisterDTO userRegisterDTO);
    }
}