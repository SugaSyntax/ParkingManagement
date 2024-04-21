
namespace ParkingManagement.Core.Entities
{
    public class Booking
    {
        public int BookingID { get; set; }
        public string CustomerName { get; set; }
        public int ParkingSpaceID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalPrice { get; set; }
        public int BookingStatusID { get; set; }
    }
}