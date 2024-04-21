using Microsoft.Extensions.Configuration;
using ParkingManagement.Core.Contracts;
using ParkingManagement.Core.Entities;
using ParkingManagement.Core.Enums;
using ParkingManagement.Core.Exceptions;
using ParkingManagement.Infrastructure.DbContexts;

namespace ParkingManagement.Infrastructure.Repositories
{
    public class UpdateRepository : IUpdateRepository
    {
        private readonly BookingDbContext _dbContext;
        private readonly IConfiguration _configuration;
        public UpdateRepository(BookingDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }
        public Task<bool> CancelBooking(int bookingID)
        {
            var booking = _dbContext.Bookings.FirstOrDefault(b => b.BookingID == bookingID);
            bool cancellationSuccess = false;

            if (booking != null && booking.BookingStatusID == 1)
            {
                //int cancelledStatusID = _dbContext.BookingStatuses.FirstOrDefault(s => s.Status == "cancelled")?.BookingStatusID ?? 0;

                    booking.BookingStatusID = (int)BookingStatusEnum.Cancelled;

                    _dbContext.SaveChanges();
                    cancellationSuccess = true;
                return Task.FromResult(cancellationSuccess);
            }
            else
            {
                throw new NotFoundException("Booking is either not in booked status or does not exist.");
            }
        }
        public async Task<BookingResponse> UpdateBooking(int bookingID, DateRange dateRange)
        {
            var existingBooking = _dbContext.Bookings.FirstOrDefault(b => b.BookingID == bookingID);

            
                if (existingBooking != null && existingBooking.BookingStatusID == (int)BookingStatusEnum.Booked)
                {
                    // Update the existing booking status to 'updated'
                    existingBooking.BookingStatusID = (int)BookingStatusEnum.Updated;
                    CreateRepository createRepository = new CreateRepository(_configuration,_dbContext);
                    BookingRequest bookingRequest = new BookingRequest
                    {
                        CustomerName = existingBooking.CustomerName,
                        StartDate = dateRange.StartDate.Value,
                        EndDate = dateRange.EndDate.Value
                    };
                    BookingResponse bookingResponse = await createRepository.CreateBooking(bookingRequest);
                    return bookingResponse;
                }
                else
                {
                    throw new NotFoundException("Booking is either not in booked status or does not exist.");
                }
        }
    }
}
    
