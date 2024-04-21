using Microsoft.AspNetCore.Mvc;
using MediatR;
using ParkingManagement.UseCases.DTOs;
using ParkingManagement.UseCases.Commands;
using ParkingManagement.Core.Entities;
using ParkingManagement.UseCases.Queries;


namespace ParkingManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingManagementController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ParkingManagementController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //GET: api/<ParkingManagement> 
        [HttpGet]
        public async Task<ActionResult<AvailableSpaces>> GetAvailableSpaces([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            DaterangeDTO daterangeDTO = new DaterangeDTO{
                StartDate = startDate,
                EndDate = endDate
            };
            var query = new GetAvailableSpacesRequest {DateRange = daterangeDTO};
            var availableSpaces = await _mediator.Send(query);
            return Ok(availableSpaces);
        }

        // GET api/<ParkingManagementController>/prices>
        [HttpGet("prices")]
        public async Task<ActionResult<PriceDTO>> GetPrices([FromQuery] DateTime fromDate, [FromQuery] DateTime toDate)
        {
            DaterangeDTO daterangeDTO = new DaterangeDTO{
                StartDate = fromDate,
                EndDate = toDate
            };
            var prices = await _mediator.Send(new GetPricesRequest { DateRange = daterangeDTO });
            return Ok(prices);
        }

        // POST api/<ParkingManagementController>
        [HttpPost]
        public async Task<ActionResult<BookingResponseDTO>> CreateBooking([FromBody] BookingRequestDTO booking)
        {
            var command = new CreateBookingCommand { BookingDetails = booking };
            var repsonse = await _mediator.Send(command);
            return Ok(repsonse);
        }

        // PUT api/<ParkingManagementController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> CancelBooking(int id)
        {
            var command = new CancelBookingCommand { BookingID = id };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<ParkingManagementController>/updateBooking/5
        [HttpPut("updateBooking/{id}")]
        public async Task<ActionResult> UpdateBooking(int id, [FromBody] DaterangeDTO daterange)
        {
            var command = new UpdateBookingCommand { BookingID = id, dateRange = daterange };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}