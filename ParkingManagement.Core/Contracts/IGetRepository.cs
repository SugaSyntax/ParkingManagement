using ParkingManagement.Core.Entities;

namespace ParkingManagement.Core.Contracts
{
    public interface IGetRepository
    {
        Task<AvailableSpaces> GetAvailableSpaces(DateRange dateRange);
        Prices GetPrices(DateRange dateRange);
    }
}