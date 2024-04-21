
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using ParkingManagement.Core.Contracts;
using ParkingManagement.Core.Entities;
using ParkingManagement.Core.Validators;
using ParkingManagement.UseCases.DTOs;

namespace ParkingManagement.UseCases.Queries
{
    public class GetAvailableSpacesRequestHandler : IRequestHandler<GetAvailableSpacesRequest, AvailablespacesDTO>
    {
        private readonly IMapper _mapper;
        private readonly IGetRepository _getRepository;
        public GetAvailableSpacesRequestHandler(IMapper mapper, IGetRepository getRepository)
        {
            _mapper = mapper;
            _getRepository = getRepository;
        }
        public async Task<AvailablespacesDTO> Handle(GetAvailableSpacesRequest request, CancellationToken cancellationToken)
        {
            var validator = new DateRangeValidator();
            var validationResult = await validator.ValidateAsync(_mapper.Map<DateRange>(request.DateRange));
            if(validationResult.IsValid == false)
            {
                string errorMessage = string.Join(Environment.NewLine, validationResult.Errors.Select(error => error.ErrorMessage));
                throw new ValidationException(errorMessage);
            }
            var spaces = await _getRepository.GetAvailableSpaces(_mapper.Map<DateRange>(request.DateRange));
            return _mapper.Map<AvailablespacesDTO>(spaces);
        }
    }
}