
namespace ParkingManagement.UseCases.DTOs
{
    public class BookingDTO
    {
        public int BookingID { get; set; }
        public string? CustomerName { get; set; }
        public int ParkingSpaceID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TotalPrice { get; set; }
        public BookingstatusDTO? Status { get; set; }

    }
}