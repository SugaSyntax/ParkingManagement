
namespace ParkingManagement.UseCases.DTOs
{
    public class AvailablespacesDTO
    {
        
        public int TotalSpaces { get; set; }
        public Dictionary<DateTime,int> AvailableSpacesPerDay { get; set; }
        //public List<string> AvailableSpacesNames { get; set; }
    }
}