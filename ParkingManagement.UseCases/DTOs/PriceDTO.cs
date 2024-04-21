
namespace ParkingManagement.UseCases.DTOs
{
    public class PriceDTO
    {
        public decimal TotalWeekdayPrice { get; set; }
        public decimal TotalWeekendPrice { get; set; }
        public decimal SeasonalPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}