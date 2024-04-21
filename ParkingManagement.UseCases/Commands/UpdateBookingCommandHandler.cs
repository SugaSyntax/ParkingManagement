using AutoMapper;
using MediatR;
using ParkingManagement.Core.Contracts;
using ParkingManagement.Core.Entities;
using ParkingManagement.Core.Validators;
using ParkingManagement.UseCases.DTOs;

namespace ParkingManagement.UseCases.Commands
{
    public class UpdateBookingCommandHandler : IRequestHandler<UpdateBookingCommand,BookingResponseDTO>
    {
        private readonly IMapper _mapper;
        private readonly IUpdateRepository _updateRepository;
        public UpdateBookingCommandHandler(IMapper mapper, IUpdateRepository updateRepository)
        {
            _mapper = mapper;
            _updateRepository = updateRepository;

        }

        public async Task<BookingResponseDTO> Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
        {
            var validator = new DateRangeValidator();
            var validationResult = await validator.ValidateAsync(_mapper.Map<DateRange>(request.dateRange));
            if(validationResult.IsValid == false)
            {
                string errorMessage = string.Join(Environment.NewLine, validationResult.Errors.Select(error => error.ErrorMessage));
                throw new Core.Exceptions.ValidationException(validationResult);
            }
            var result = await _updateRepository.UpdateBooking(request.BookingID,_mapper.Map<DateRange>(request.dateRange));
            return _mapper.Map<BookingResponseDTO>(result); 
        }
    }
}
