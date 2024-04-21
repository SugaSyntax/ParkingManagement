
namespace ParkingManagement.Core.Entities
{
    public class AvailableSpaces
    {
        public int TotalSpaces { get; set; }
        public Dictionary<DateTime,int> AvailableSpacesPerDay { get; set; }
        //public List<string> AvailableSpacesNames { get; set; }
    }
}