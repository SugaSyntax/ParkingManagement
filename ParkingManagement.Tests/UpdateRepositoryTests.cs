using System;
using System.Threading.Tasks;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ParkingManagement.Core.Contracts;
using ParkingManagement.Core.Entities;
using ParkingManagement.Infrastructure.Repositories;
using ParkingManagement.Infrastructure.DbContexts;
using ParkingManagement.Core.Enums;


namespace ParkingManagement.Tests
{
    public class UpdateRepositoryTests
    {
        private IConfiguration _configuration;
        private DbContextOptions<BookingDbContext> _options;

        public UpdateRepositoryTests()
        {
            // Initialize the configuration
            // _configuration = new ConfigurationBuilder()
            //     .AddJsonFile("appsettings.json")
            //     .Build();

            // Initialize the DbContextOptions with an in-memory database provider
            _options = new DbContextOptionsBuilder<BookingDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
        }

        [Fact]
        public async Task CancelBooking_ExistingBookingInBookedStatus_CancelsBooking()
        {
            // Arrange
            using (var dbContext = new BookingDbContext(_options))
            {
                // Seed the in-memory database with a booking in the booked status
                var bookedBooking = new Booking
                {
                    BookingID = 1,
                    CustomerName = "John Doe",
                    StartDate = DateTime.Today.AddDays(1),
                    EndDate = DateTime.Today.AddDays(3),
                    BookingStatusID = (int)BookingStatusEnum.Booked
                };
                dbContext.Add(bookedBooking);
                dbContext.SaveChanges();
            }

            // Act
            using (var dbContext = new BookingDbContext(_options))
            {
                var updateRepository = new UpdateRepository(dbContext, _configuration);
                var cancellationSuccess = await updateRepository.CancelBooking(1);

                // Assert
                Assert.True(cancellationSuccess);

                // Verify that the booking status has been updated to cancelled
                var cancelledBooking = await dbContext.Bookings.FindAsync(1);
                Assert.Equal((int)BookingStatusEnum.Cancelled, cancelledBooking.BookingStatusID);
            }
        }

        [Fact]
        public async Task UpdateBooking_ExistingBookingInBookedStatus_UpdatesBooking()
        {
            // Arrange
            // using (var dbContext = new BookingDbContext(_options))
            // {
            //     // Seed the in-memory database with a booking in the booked status
            //     var bookedBooking = new Booking
            //     {
            //         BookingID = 2,
            //         CustomerName = "Jane Smith",
            //         StartDate = DateTime.Today.AddDays(5),
            //         EndDate = DateTime.Today.AddDays(7),
            //         BookingStatusID = (int)BookingStatusEnum.Booked
            //     };
            //     dbContext.Add(bookedBooking);
            //     dbContext.SaveChanges();
            // }

            // var newStartDate = DateTime.Today.AddDays(8);
            // var newEndDate = DateTime.Today.AddDays(10);

            // // Act
            // using (var dbContext = new BookingDbContext(_options))
            // {
            //     var updateRepository = new UpdateRepository(dbContext, _configuration);
            //     var bookingResponse = await updateRepository.UpdateBooking(2, new DateRange { StartDate = newStartDate, EndDate = newEndDate });

            //     // Assert
            //     Assert.NotNull(bookingResponse);

            //     // Verify that the existing booking status has been updated to updated
            //     var updatedBooking = await dbContext.Bookings.FindAsync(2);
            //     Assert.Equal((int)BookingStatusEnum.Updated, updatedBooking.BookingStatusID);

            //     // Verify that a new booking has been created with the updated date range
            //     var newBooking = await dbContext.Bookings.FindAsync(3);
            //     Assert.Equal(newStartDate, newBooking.StartDate);
            //     Assert.Equal(newEndDate, newBooking.EndDate);
            // }
        }
    }
}
