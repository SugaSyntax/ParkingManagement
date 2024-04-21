using Microsoft.Extensions.Configuration;
using ParkingManagement.Core.Contracts;
using ParkingManagement.Core.Entities;
using ParkingManagement.Core.Enums;
using ParkingManagement.Infrastructure.DbContexts;

namespace ParkingManagement.Infrastructure.Repositories
{
    public class CreateRepository : ICreateRepository
    {
        private readonly BookingDbContext _dbContext;
        private readonly IConfiguration _configuration;
        public CreateRepository(IConfiguration configuration,BookingDbContext dbContext)
        {
            _configuration = configuration;
            _dbContext = dbContext;   
        }

        public async Task<BookingResponse> CreateBooking(BookingRequest bookingRequest)
        {   
            DateRange dateRange = new DateRange{
                StartDate = bookingRequest.StartDate,
                EndDate = bookingRequest.EndDate
            };
            GetRepository getRepository = new GetRepository(_configuration,_dbContext);
            AvailableSpaces availableSpaces = await getRepository.GetAvailableSpaces(dateRange);
            List<string> availableSpacesNames = getRepository.GetAvailableSpacesNamesForDateRange(dateRange).ToList();
            Prices prices = getRepository.GetPrices(dateRange);       
            Booking booking = new Booking
            {
                CustomerName = bookingRequest.CustomerName,
                StartDate = bookingRequest.StartDate,
                EndDate = bookingRequest.EndDate,
                BookingStatusID = (int)BookingStatusEnum.Booked,
                ParkingSpaceID = _dbContext.ParkingSpaces.FirstOrDefault(p=> p.ParkingSpaceName == availableSpacesNames[1]).ParkingSpaceID,
                TotalPrice = prices.TotalPrice
            };
           _dbContext.Bookings.Add(booking);
            await _dbContext.SaveChangesAsync();
            BookingResponse bookingResponse = new BookingResponse
            {
                BookingID = booking.BookingID,
                ParkingSpaceID = booking.ParkingSpaceID
            };

            return bookingResponse;
        }
    }
}