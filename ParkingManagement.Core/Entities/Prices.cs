
namespace ParkingManagement.Core.Entities
{
    public class Prices
    {
        public decimal TotalWeekdayPrice { get; set; }
        public decimal TotalWeekendPrice { get; set; }
        public decimal SeasonalPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}