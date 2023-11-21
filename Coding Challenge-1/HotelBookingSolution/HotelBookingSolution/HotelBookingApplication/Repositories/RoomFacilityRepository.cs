using HotelBookingApplication.Contexts;
using HotelBookingApplication.Interfaces;
using HotelBookingApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApplication.Repositories
{
    public class RoomFacilityRepository : IRepository<int, RoomFacility>
    {
        private readonly BookingContext _context;

        public RoomFacilityRepository(BookingContext context)
        {
            _context = context;
        }
        public RoomFacility Add(RoomFacility entity)
        {
            _context.RoomFacilities.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public RoomFacility Delete(int key)
        {
            var facilities = GetById(key);
            if (facilities != null)
            {
                _context.RoomFacilities.Remove(facilities);
                _context.SaveChanges();
                return facilities;
            }
            return null;
        }

        public IList<RoomFacility> GetAll()
        {
            if (_context.RoomFacilities.Count() == 0)
                return null;
            return _context.RoomFacilities.ToList();
        }

        public RoomFacility GetById(int key)
        {
            var facility = _context.RoomFacilities.SingleOrDefault(u => u.RoomFacilityId == key);
            return facility;
        }

        public RoomFacility Update(RoomFacility entity)
        {
            var facility = GetById(entity.RoomFacilityId);
            if (facility != null)
            {
                _context.Entry<RoomFacility>(facility).State = EntityState.Modified;
                _context.SaveChanges();
                return facility;
            }
            return null;
        }
    }
}