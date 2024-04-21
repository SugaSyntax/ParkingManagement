using MediatR;
using ParkingManagement.UseCases.DTOs;

namespace ParkingManagement.UseCases.Commands
{
    public class UpdateBookingCommand : IRequest<BookingResponseDTO>
    {
        public int BookingID { get; set; }
        public DaterangeDTO dateRange { get; set; }
    }
}