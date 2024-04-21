﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParkingManagement.Infrastructure.DbContexts;

#nullable disable

namespace ParkingManagement.Infrastructure.Migrations
{
    [DbContext(typeof(BookingDbContext))]
    partial class BookingDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("ParkingManagement.Core.Entities.Booking", b =>
                {
                    b.Property<int>("BookingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BookingStatusID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("ParkingSpaceID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("TEXT");

                    b.HasKey("BookingID");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("ParkingManagement.Core.Entities.BookingStatus", b =>
                {
                    b.Property<int>("BookingStatusID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("BookingStatusID");

                    b.ToTable("BookingStatuses");
                });

            modelBuilder.Entity("ParkingManagement.Core.Entities.ParkingSpace", b =>
                {
                    b.Property<int>("ParkingSpaceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ParkingSpaceName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ParkingSpaceID");

                    b.ToTable("ParkingSpaces");
                });
#pragma warning restore 612, 618
        }
    }
}
