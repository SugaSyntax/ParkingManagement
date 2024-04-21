
using ParkingManagement.Core.Entities;

namespace ParkingManagement.Core.Contracts
{
    public interface ICreateRepository
    {
        Task<BookingResponse> CreateBooking(BookingRequest bookingRequest);
    }
}