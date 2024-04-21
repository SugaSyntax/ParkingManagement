
using MediatR;
using ParkingManagement.UseCases.DTOs;

namespace ParkingManagement.UseCases.Commands
{
    public class CreateBookingCommand : IRequest<BookingResponseDTO>
    {
        public BookingRequestDTO? BookingDetails { get; set; }
    }
}