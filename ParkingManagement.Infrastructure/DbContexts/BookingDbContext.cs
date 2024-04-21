using Microsoft.EntityFrameworkCore;
using ParkingManagement.Core.Contracts;
using ParkingManagement.Core.Entities;

namespace ParkingManagement.Infrastructure.DbContexts
{
    public class BookingDbContext : DbContext
    {
        // public IQueryable<Booking> Bookings => Set<Booking>();
        // public IQueryable<BookingStatus> BookingStatuses => Set<BookingStatus>();
        // public IQueryable<ParkingSpace> ParkingSpaces => Set<ParkingSpace>();
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<BookingStatus> BookingStatuses { get; set; }
        public virtual DbSet<ParkingSpace> ParkingSpaces { get; set; }
        public BookingDbContext(DbContextOptions<BookingDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>()
                .HasKey(b => b.BookingID); 

            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
        
    }
}