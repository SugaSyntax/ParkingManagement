
using AutoMapper;
using MediatR;
using FluentValidation;
using ParkingManagement.Core.Contracts;
using ParkingManagement.Core.Entities;
using ParkingManagement.Core.Exceptions;
using ParkingManagement.Core.Validators;
using ParkingManagement.UseCases.DTOs;

namespace ParkingManagement.UseCases.Commands
{
    public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, BookingResponseDTO>
    {
        private readonly IMapper _mapper;
        private readonly ICreateRepository _createRepository;
        public CreateBookingCommandHandler(IMapper mapper, ICreateRepository createRepository)
        {
            _mapper = mapper;
            _createRepository = createRepository;

        }

        public async Task<BookingResponseDTO> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            DateRange dateRange = new DateRange{
                StartDate = request.BookingDetails.StartDate,
                EndDate = request.BookingDetails.EndDate
            };
            var validator = new DateRangeValidator();
            var validationResult = await validator.ValidateAsync(_mapper.Map<DateRange>(dateRange));
            if(validationResult.IsValid == false)
            {
                string errorMessage = string.Join(Environment.NewLine, validationResult.Errors.Select(error => error.ErrorMessage));
                throw new Core.Exceptions.ValidationException(validationResult);
            }
            var response = await _createRepository.CreateBooking(_mapper.Map<BookingRequest>(request.BookingDetails));
            return _mapper.Map<BookingResponseDTO>(response);
            //Throw custom validationException
        }
    }
}