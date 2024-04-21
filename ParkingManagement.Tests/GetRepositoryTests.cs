using System;
using Xunit;
using Moq;
using FluentAssertions;
using ParkingManagement.Core.Entities;
using ParkingManagement.Core.Contracts;
using ParkingManagement.Core.Validators;
using ParkingManagement.UseCases.Queries;
using ParkingManagement.UseCases.DTOs;
using ParkingManagement.Infrastructure.Configurations;
using ParkingManagement.Infrastructure.DbContexts;
using FluentValidation;
using FluentValidation.Results;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ParkingManagement.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;

namespace ParkingManagement.Tests
{
    public class GetRepositoryTests : TestFixture
    {
        [Fact]
        public async void GetAvailableSpaces_ReturnsCorrectAvailableSpaces()
        {
            // Arrange
            // SeedDatabase();

            // var repository = new GetRepository(null, _dbContext);
            // var dateRange = new DateRange
            // {
            //     StartDate = new DateTime(2024, 5, 1), 
            //     EndDate = new DateTime(2024, 5, 3)
            // };

            // // Act
            // var availableSpaces = await repository.GetAvailableSpaces(dateRange);

            // // Assert
            // Assert.NotNull(availableSpaces);
            // Assert.Equal(8, availableSpaces.TotalSpaces);
            //Assert.Equal(8, availableSpaces.AvailableSpacesPerDay.Count);
         }

         [Fact]
        public void GetPrices_ReturnsCorrectPrices()
        {
            // Arrange
            // var dateRange = new DateRange
            // {
            //     StartDate = new DateTime(2024, 5, 1),
            //     EndDate = new DateTime(2024, 5, 3)
            // };

            // // Mock IConfiguration
            // var configuration = new Mock<IConfiguration>();

            // // Mock BookingDbContext
            // var dbContext = new Mock<BookingDbContext>();

            // // Mock CommonRepository
            // var commonRepository = new Mock<CommonRepository>(configuration, dbContext);
            // commonRepository.CallBase = true; // Allow calling base class method

            // // Mock GetRepository
            // var getRepository = new Mock<GetRepository>(configuration, dbContext);
            // getRepository.CallBase = true; // Allow calling base class method
            // getRepository.Setup(x => x.GetAvailableSpacesNamesForDateRange(It.IsAny<DateRange>())).Returns(new List<string> { "Space1", "Space2" });
            // getRepository.Setup(x => x.GetAvailableSpacesForDateRange(It.IsAny<DateRange>())).Returns(new Dictionary<DateTime, int>
            // {
            //     { new DateTime(2024, 5, 1), 7 },
            //     { new DateTime(2024, 5, 2), 8 },
            //     { new DateTime(2024, 5, 3), 9 }
            // });

            // // Create an instance of GetRepository using the mocked objects
            // var repository = getRepository.Object;

            // // Act
            // var result = repository.GetPrices(dateRange);

            // // Assert
            // Assert.NotNull(result);
            // //Assert.Equal(2, result.TotalSpaces); // TotalSpaces should be the count of available spaces names
            // //Assert.Equal(2, result.AvailableSpacesPerDay.Count); // AvailableSpacesPerDay should have two entries
            // Assert.Equal(10, result.TotalWeekdayPrice); // Assuming weekday price is 10
            // Assert.Equal(0, result.TotalWeekendPrice); // Assuming weekend price is 0
            // Assert.Equal(20, result.TotalPrice); // TotalPrice should be the sum of TotalWeekdayPrice and TotalWeekendPrice
        }
    }
}
