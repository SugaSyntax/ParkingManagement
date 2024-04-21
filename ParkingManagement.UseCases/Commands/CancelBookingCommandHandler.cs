
using AutoMapper;
using MediatR;
using ParkingManagement.Core.Contracts;
using ParkingManagement.Core.Entities;
using ParkingManagement.UseCases.DTOs;

namespace ParkingManagement.UseCases.Commands
{
    public class CancelBookingCommandHandler : IRequestHandler<CancelBookingCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IUpdateRepository _updateRepository;
        public CancelBookingCommandHandler(IMapper mapper, IUpdateRepository updateRepository)
        {
            _mapper = mapper;
            _updateRepository = updateRepository;

        }

        public Task<bool> Handle(CancelBookingCommand request, CancellationToken cancellationToken)
        {
            var result = _updateRepository.CancelBooking(request.BookingID);
            return result; 
        }
    }
}