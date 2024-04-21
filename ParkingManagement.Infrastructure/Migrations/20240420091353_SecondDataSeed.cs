using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SecondDataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
            table: "ParkingSpaces",
            columns: new[] { "ParkingSpaceID", "ParkingSpaceName" },
            values: new object[,]
            {
                { 101, "P101" },
                { 102, "P102" },
                { 103, "P103" },
                { 104, "P104" },
                { 105, "P105" },
                { 106, "P106" },
                { 107, "P107" },
                { 108, "P108" },
                { 109, "P109" },
                { 110, "P110" }
            });

            migrationBuilder.InsertData(
            table: "Bookings",
            columns: new[] { "BookingID", "CustomerName", "ParkingSpaceID", "StartDate", "EndDate", "TotalPrice", "BookingStatusID" },
            values: new object[,]
            {
                { 1, "John Doe", 101, new DateTime(2024, 5, 1), new DateTime(2024, 5, 3), 100.00m, 1 },
                { 2, "Jane Smith", 102, new DateTime(2024, 5, 5), new DateTime(2024, 5, 7), 150.00m, 1 },
                { 3, "Boyd Rasmussen", 107,new DateTime(2024, 5, 10), new DateTime(2024, 5, 12), 100.00m, 1},
                {4, "Dennis Davies", 107,new DateTime(2024, 5, 5), new DateTime(2024, 5, 15), 150.00m, 4},
                {5, "Reba Downs", 109,new DateTime(2024, 5, 2), new DateTime(2024, 5, 4), 100.00m, 5},
                {6, "Arline Bullock", 104,new DateTime(2024, 4, 25), new DateTime(2024, 4, 27), 100.00m, 1}
            });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
