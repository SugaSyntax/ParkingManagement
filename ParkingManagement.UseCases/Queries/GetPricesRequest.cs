
using MediatR;
using ParkingManagement.UseCases.DTOs;

namespace ParkingManagement.UseCases.Queries
{
    public class GetPricesRequest: IRequest<PriceDTO>
    {
        public DaterangeDTO? DateRange { get; set; }
    }
}