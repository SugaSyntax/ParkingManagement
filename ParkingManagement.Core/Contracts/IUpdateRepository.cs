
using ParkingManagement.Core.Entities;

namespace ParkingManagement.Core.Contracts
{
    public interface IUpdateRepository
    {
        Task<bool> CancelBooking(int bookingID);
        Task<BookingResponse> UpdateBooking(int bookingID, DateRange dateRange);
    }
}