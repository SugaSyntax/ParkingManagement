using ParkingManagement.Core.Entities;

namespace ParkingManagement.Core.Contracts
{
    public interface IBookingDbContext
    {
        IQueryable<Booking> Bookings { get; }
        IQueryable<BookingStatus> BookingStatuses {get; }
        IQueryable<ParkingSpace> ParkingSpaces { get; }
    } 
}