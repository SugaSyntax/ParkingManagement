
using MediatR;
using ParkingManagement.UseCases.DTOs;

namespace ParkingManagement.UseCases.Queries
{
    public class GetAvailableSpacesRequest: IRequest<AvailablespacesDTO>
    {
        public DaterangeDTO? DateRange { get; set; }
    }
}