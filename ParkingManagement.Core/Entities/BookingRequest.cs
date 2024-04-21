namespace ParkingManagement.Core.Entities
{
    public class BookingRequest
    {
        public string CustomerName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}