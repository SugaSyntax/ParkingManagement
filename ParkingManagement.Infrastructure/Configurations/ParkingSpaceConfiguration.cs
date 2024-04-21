
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingManagement.Core.Entities;

namespace ParkingManagement.Infrastructure.Configurations
{
    public class ParkingSpaceConfiguration : IEntityTypeConfiguration<ParkingSpace>
    {
        public void Configure(EntityTypeBuilder<ParkingSpace> builder)
        {
            builder.HasData(
                new ParkingSpace{
                    ParkingSpaceID = 101,
                    ParkingSpaceName = "P101"
                },
                new ParkingSpace{
                    ParkingSpaceID = 102,
                    ParkingSpaceName = "P102"
                },
                new ParkingSpace{
                    ParkingSpaceID = 103,
                    ParkingSpaceName = "P103"
                },
                new ParkingSpace{
                    ParkingSpaceID = 104,
                    ParkingSpaceName = "P104"
                },
                new ParkingSpace{
                    ParkingSpaceID = 105,
                    ParkingSpaceName = "P105"
                },
                new ParkingSpace{
                    ParkingSpaceID = 106,
                    ParkingSpaceName = "P106"
                },
                new ParkingSpace{
                    ParkingSpaceID = 107,
                    ParkingSpaceName = "P107"
                },
                new ParkingSpace{
                    ParkingSpaceID = 108,
                    ParkingSpaceName = "P108"
                },
                new ParkingSpace{
                    ParkingSpaceID = 109,
                    ParkingSpaceName = "P109"
                },
                new ParkingSpace{
                    ParkingSpaceID = 110,
                    ParkingSpaceName = "P110"
                }
            );
        }
    }
}