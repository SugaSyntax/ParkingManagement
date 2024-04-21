using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using ParkingManagement.Core.Entities;
using ParkingManagement.Infrastructure.DbContexts;

namespace ParkingManagement.Tests
{
    public class TestFixture
    {
        protected BookingDbContext _dbContext;

        public TestFixture()
        {
            // Create a DbContextOptions instance with an in-memory database provider
            var options = new DbContextOptionsBuilder<BookingDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            // Create an instance of BookingDbContext using the options
            _dbContext = new BookingDbContext(options);
        }

        public void SeedDatabase()
        {
            // Add some bookings for testing
            _dbContext.Bookings.AddRange(new List<Booking>
            {
                new Booking
                {
                    BookingID = 1,
                    CustomerName = "John Doe",
                    ParkingSpaceID = 101,
                    StartDate = new DateTime(2024, 5, 1),
                    EndDate = new DateTime(2024, 5, 3),
                    TotalPrice = 100.00m,
                    BookingStatusID = 1 
                },
                new Booking
                {
                    BookingID = 2,
                    CustomerName = "Jane Smith",
                    ParkingSpaceID = 102,
                    StartDate = new DateTime(2024, 5, 5),
                    EndDate = new DateTime(2024, 5, 7),
                    TotalPrice = 150.00m,
                    BookingStatusID = 1 
                },
                new Booking
                {
                    BookingID = 3,
                    CustomerName = "Boyd Rasmussen",
                    ParkingSpaceID = 101,
                    StartDate = new DateTime(2024, 5, 10),
                    EndDate = new DateTime(2024, 5, 12),
                    TotalPrice = 100.00m,
                    BookingStatusID = 1 
                },
                new Booking
                {
                    BookingID = 4,
                    CustomerName = "Dennis Davies",
                    ParkingSpaceID = 102,
                    StartDate = new DateTime(2024, 5, 5),
                    EndDate = new DateTime(2024, 5, 15),
                    TotalPrice = 150.00m,
                    BookingStatusID = 1 
                },new Booking
                {
                    BookingID = 5,
                    CustomerName = "Reba Downs",
                    ParkingSpaceID = 101,
                    StartDate = new DateTime(2024, 5, 2),
                    EndDate = new DateTime(2024, 5, 4),
                    TotalPrice = 100.00m,
                    BookingStatusID = 1 
                },
                new Booking
                {
                    BookingID = 6,
                    CustomerName = "Arline Bullock",
                    ParkingSpaceID = 102,
                    StartDate = new DateTime(2024, 4, 25),
                    EndDate = new DateTime(2024, 4, 27),
                    TotalPrice = 150.00m,
                    BookingStatusID = 1
                }
            });

            // Save changes to persist the seeded data in the in-memory database
            _dbContext.SaveChanges();
        }
    }
}
