
using AutoMapper;
using FluentValidation;
using MediatR;
using ParkingManagement.Core.Contracts;
using ParkingManagement.Core.Entities;
using ParkingManagement.Core.Validators;
using ParkingManagement.UseCases.DTOs;

namespace ParkingManagement.UseCases.Queries
{
    public class GetPricesRequestHandler : IRequestHandler<GetPricesRequest, PriceDTO>
    {
        private readonly IMapper _mapper;
        private readonly IGetRepository _getRepository;
        public GetPricesRequestHandler(IMapper mapper, IGetRepository getRepository)
        {
            _mapper = mapper;
            _getRepository = getRepository;
        }
        public async Task<PriceDTO> Handle(GetPricesRequest request, CancellationToken cancellationToken)
        {
            var validator = new DateRangeValidator();
            var validationResult = await validator.ValidateAsync(_mapper.Map<DateRange>(request.DateRange));
            if(validationResult.IsValid == false)
            {
                string errorMessage = string.Join(Environment.NewLine, validationResult.Errors.Select(error => error.ErrorMessage));
                throw new ValidationException(errorMessage);
            }
            var prices = _getRepository.GetPrices(_mapper.Map<DateRange>(request.DateRange));
            return _mapper.Map<PriceDTO>(prices);
        }
    }
}