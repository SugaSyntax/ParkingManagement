namespace ParkingManagement.UseCases.DTOs
{
    public class BookingRequestDTO
    {
        public string CustomerName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}