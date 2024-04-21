using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialDataSeed : Migration
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
