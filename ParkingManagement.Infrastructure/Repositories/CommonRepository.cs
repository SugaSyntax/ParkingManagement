using Microsoft.Extensions.Configuration;
using ParkingManagement.Core.Contracts;
using ParkingManagement.Core.Entities;
using ParkingManagement.Infrastructure.DbContexts;

namespace ParkingManagement.Infrastructure.Repositories
{
    public class CommonRepository
    {
        private readonly IConfiguration _configuration;
        private readonly BookingDbContext _dbContext;
        public CommonRepository(IConfiguration configuration, BookingDbContext dbContext)
        {
            _configuration = configuration;
            _dbContext = dbContext;
        }

        public Prices CalculateParkingPrice(DateRange dateRange)
            {
                var parkingPricesSection = _configuration.GetSection("ParkingPrices");
                // Calculate the duration of the parking in days
                int totalDays = (int)(dateRange.EndDate.Value - dateRange.StartDate.Value).TotalDays;

                // Initialize price variables
                decimal totalPrice = 0;
                decimal totalDailyPrice = 0;
                decimal totalSeasonalPrice = 0;
                decimal totalWeekendPrice = 0;
                decimal totalWeekdayPrice = 0;

                // Loop through each day of the parking period
                for (int i = 0; i < totalDays; i++)
                {
                    // Get the current date in the parking period
                    DateTime currentDate = dateRange.StartDate.Value.AddDays(i);

                    // Check if the current date is a weekday or weekend
                    bool isWeekend = currentDate.DayOfWeek == DayOfWeek.Saturday || currentDate.DayOfWeek == DayOfWeek.Sunday;

                    // Check if there are any seasonal pricing rules for the current date
                    decimal seasonalPrice = GetSeasonalPrice(currentDate);

                    // Calculate the price based on weekday/weekend and seasonal pricing
                    decimal dailyPrice = isWeekend ? parkingPricesSection.GetValue<Decimal>("WeekendPrice") : parkingPricesSection.GetValue<Decimal>("WeekdayPrice");
                    if (isWeekend)
                        totalWeekendPrice += dailyPrice;
                    else
                        totalWeekdayPrice += dailyPrice;

                    totalDailyPrice += dailyPrice;
                    totalSeasonalPrice += seasonalPrice;
                    totalPrice = totalDailyPrice + totalSeasonalPrice;
                }

                Prices prices = new Prices{
                    TotalWeekdayPrice = totalWeekdayPrice,
                    TotalWeekendPrice = totalWeekendPrice,
                    SeasonalPrice = totalSeasonalPrice,
                    TotalPrice = totalPrice
                };

                return prices;
            }
            
        public decimal GetSeasonalPrice(DateTime currentDate)
        {
            
            var parkingPricesSection = _configuration.GetSection("ParkingPrices");
            decimal seasonalPrice = 0;
            if (currentDate.Month >= 6 && currentDate.Month <= 8) // Summer season (June to August)
            {
                seasonalPrice += parkingPricesSection.GetValue<Decimal>("WeekendPrice");
            }
            else if (currentDate.Month >= 12 || currentDate.Month <= 2) // Winter season (December to February)
            {
                seasonalPrice += parkingPricesSection.GetValue<Decimal>("WinterPrice");
            }

            return seasonalPrice;
        }
        public bool IsBookingActive(int bookingID)
        {
            var booking = _dbContext.Bookings.FirstOrDefault(b => b.BookingID == bookingID);
            return booking != null && booking.BookingStatusID == 1;
        }
    }
}