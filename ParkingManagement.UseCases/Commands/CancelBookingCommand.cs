using MediatR;

namespace ParkingManagement.UseCases.Commands
{
    public class CancelBookingCommand : IRequest<bool>
    {
        public int BookingID { get; set; }
    }
}
