using Microsoft.Extensions.Configuration;
using ParkingManagement.Core.Contracts;
using ParkingManagement.Core.Entities;
using ParkingManagement.Infrastructure.DbContexts;

namespace ParkingManagement.Infrastructure.Repositories
{
    
    public class GetRepository : IGetRepository
    {
        private readonly IConfiguration _configuration;
        private readonly BookingDbContext _dbContext;
        public GetRepository(IConfiguration configuration, BookingDbContext dbContext)
        {
         _configuration = configuration;
         _dbContext = dbContext;   
        }
        public async Task<AvailableSpaces> GetAvailableSpaces(DateRange dateRange)
        {
            List<string> availableSpacesNames = GetAvailableSpacesNamesForDateRange(dateRange).ToList();
            AvailableSpaces availableSpaces = new AvailableSpaces{};
            availableSpaces.AvailableSpacesPerDay = GetAvailableSpacesForDateRange(dateRange);
            //availableSpaces.AvailableSpacesNames = GetAvailableSpacesNamesForDateRange(dateRange).ToList();
            availableSpaces.TotalSpaces = availableSpacesNames.Count;
            return await Task.FromResult(availableSpaces);
        }
        public Prices GetPrices(DateRange dateRange)
        {
            CommonRepository commonRepository = new CommonRepository(_configuration, _dbContext);
            Prices parkingPrices = commonRepository.CalculateParkingPrice(dateRange);
            return parkingPrices;

        }

        public Dictionary<DateTime, int> GetAvailableSpacesForDateRange(DateRange dateRange)
        {
            var availableSpaces = new Dictionary<DateTime, int>();

            for (DateTime date = dateRange.StartDate.Value; date <= dateRange.EndDate.Value; date = date.AddDays(1))
            {
                int bookedSpaces = _dbContext.Bookings
                    .Count(b => date >= b.StartDate && date <= b.EndDate && (b.BookingStatusID == 1 || b.BookingStatusID == 2));

                int availableSpaceCount = 10 - bookedSpaces;
                availableSpaces.Add(date, availableSpaceCount);
            }

            return availableSpaces;
        }

        public IEnumerable<string> GetAvailableSpacesNamesForDateRange(DateRange dateRange)
        {
            var availableSpacesNames = _dbContext.ParkingSpaces
                .Where(ps => !_dbContext.Bookings.Any(b => b.ParkingSpaceID == ps.ParkingSpaceID &&
                                                         dateRange.StartDate.Value <= b.EndDate && dateRange.EndDate.Value >= b.StartDate && (b.BookingStatusID == 1 || b.BookingStatusID == 2)))
                .Select(ps => ps.ParkingSpaceName)
                .ToList();

            return availableSpacesNames;
        }
    }
}