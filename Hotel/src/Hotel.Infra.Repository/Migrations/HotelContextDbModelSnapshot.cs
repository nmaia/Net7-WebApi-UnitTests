﻿// <auto-generated />
using System;
using Hotel.Infra.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hotel.Infra.Repository.Migrations
{
    [DbContext(typeof(HotelContextDb))]
    partial class HotelContextDbModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Hotel.Domain.Entities.Booking", b =>
                {
                    b.Property<Guid>("BookingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CheckinDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CheckinDate");

                    b.Property<DateTime>("CheckoutDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CheckoutDate");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedDate");

                    b.Property<Guid>("CustomerID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("HotelID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2")
                        .HasColumnName("LastUpdate");

                    b.Property<Guid>("RoomID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("TotalCost")
                        .HasColumnType("decimal")
                        .HasColumnName("TotalCost");

                    b.HasKey("BookingID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("HotelID");

                    b.HasIndex("RoomID");

                    b.ToTable("Bookings", (string)null);

                    b.HasData(
                        new
                        {
                            BookingID = new Guid("e5152512-aacc-4f9e-9f6c-b93a943549ea"),
                            CheckinDate = new DateTime(2023, 3, 9, 12, 11, 4, 923, DateTimeKind.Local).AddTicks(1675),
                            CheckoutDate = new DateTime(2023, 3, 10, 12, 11, 4, 923, DateTimeKind.Local).AddTicks(1684),
                            CreatedDate = new DateTime(2023, 3, 8, 12, 11, 4, 923, DateTimeKind.Local).AddTicks(1685),
                            CustomerID = new Guid("94063471-607a-4143-9148-1c526c35f4cc"),
                            LastUpdate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RoomID = new Guid("31342b41-1dee-491a-8dd6-6c03af271b9b"),
                            TotalCost = 100m
                        },
                        new
                        {
                            BookingID = new Guid("b44e8583-3f36-41fc-9533-131f02632c9f"),
                            CheckinDate = new DateTime(2023, 3, 9, 12, 11, 4, 923, DateTimeKind.Local).AddTicks(1701),
                            CheckoutDate = new DateTime(2023, 3, 10, 12, 11, 4, 923, DateTimeKind.Local).AddTicks(1702),
                            CreatedDate = new DateTime(2023, 3, 8, 12, 11, 4, 923, DateTimeKind.Local).AddTicks(1703),
                            CustomerID = new Guid("b835f178-9fef-417a-a396-be36ccd6af9c"),
                            LastUpdate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RoomID = new Guid("c6643f13-4937-4014-9730-5e444efac094"),
                            TotalCost = 100m
                        },
                        new
                        {
                            BookingID = new Guid("c88e50f5-98b7-47e7-8902-622062a3f3e8"),
                            CheckinDate = new DateTime(2023, 3, 9, 12, 11, 4, 923, DateTimeKind.Local).AddTicks(1709),
                            CheckoutDate = new DateTime(2023, 3, 10, 12, 11, 4, 923, DateTimeKind.Local).AddTicks(1710),
                            CreatedDate = new DateTime(2023, 3, 8, 12, 11, 4, 923, DateTimeKind.Local).AddTicks(1711),
                            CustomerID = new Guid("0121e7c3-281d-4550-a5d3-52810055a759"),
                            LastUpdate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RoomID = new Guid("b6172848-ad8f-4a60-8fbd-4b69a7226732"),
                            TotalCost = 100m
                        },
                        new
                        {
                            BookingID = new Guid("ffdbac65-422c-4543-ad30-68720e5a16ee"),
                            CheckinDate = new DateTime(2023, 3, 9, 12, 11, 4, 923, DateTimeKind.Local).AddTicks(1715),
                            CheckoutDate = new DateTime(2023, 3, 10, 12, 11, 4, 923, DateTimeKind.Local).AddTicks(1715),
                            CreatedDate = new DateTime(2023, 3, 8, 12, 11, 4, 923, DateTimeKind.Local).AddTicks(1716),
                            CustomerID = new Guid("44f8215f-df3f-48f3-b53d-5dc88eb33622"),
                            LastUpdate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RoomID = new Guid("d5c82e94-c3af-4780-8d73-8b05ee00a683"),
                            TotalCost = 100m
                        });
                });

            modelBuilder.Entity("Hotel.Domain.Entities.Customer", b =>
                {
                    b.Property<Guid>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("date")
                        .HasColumnName("BirthDate");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedDate");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Email");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2")
                        .HasColumnName("LastUpdate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Name");

                    b.Property<int>("SIN")
                        .HasMaxLength(9)
                        .HasColumnType("integer")
                        .HasColumnName("SIN");

                    b.HasKey("CustomerID");

                    b.ToTable("Customers", (string)null);

                    b.HasData(
                        new
                        {
                            CustomerID = new Guid("94063471-607a-4143-9148-1c526c35f4cc"),
                            BirthDate = new DateTime(1967, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedDate = new DateTime(2023, 3, 8, 12, 11, 4, 923, DateTimeKind.Local).AddTicks(1588),
                            Email = "zakk@mail.com",
                            LastUpdate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Zakk Wylde",
                            SIN = 123456789
                        },
                        new
                        {
                            CustomerID = new Guid("b835f178-9fef-417a-a396-be36ccd6af9c"),
                            BirthDate = new DateTime(1948, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedDate = new DateTime(2023, 3, 8, 12, 11, 4, 923, DateTimeKind.Local).AddTicks(1604),
                            Email = "ozzy@mail.com",
                            LastUpdate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Ozzy Osbourne",
                            SIN = 987654321
                        },
                        new
                        {
                            CustomerID = new Guid("0121e7c3-281d-4550-a5d3-52810055a759"),
                            BirthDate = new DateTime(1971, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedDate = new DateTime(2023, 3, 8, 12, 11, 4, 923, DateTimeKind.Local).AddTicks(1613),
                            Email = "randy@mail.com",
                            LastUpdate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Randy Blythe",
                            SIN = 111456222
                        },
                        new
                        {
                            CustomerID = new Guid("44f8215f-df3f-48f3-b53d-5dc88eb33622"),
                            BirthDate = new DateTime(1942, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedDate = new DateTime(2023, 3, 8, 12, 11, 4, 923, DateTimeKind.Local).AddTicks(1623),
                            Email = "dio@mail.com",
                            LastUpdate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Ronnie James Dio",
                            SIN = 222456333
                        },
                        new
                        {
                            CustomerID = new Guid("ddeffc9e-7cea-4d9d-823b-e2bbbfa6dc97"),
                            BirthDate = new DateTime(1963, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedDate = new DateTime(2023, 3, 8, 12, 11, 4, 923, DateTimeKind.Local).AddTicks(1633),
                            Email = "james@mail.com",
                            LastUpdate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "James Hetfield",
                            SIN = 333456444
                        });
                });

            modelBuilder.Entity("Hotel.Domain.Entities.Hotel", b =>
                {
                    b.Property<Guid>("HotelID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedDate");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2")
                        .HasColumnName("LastUpdate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("HotelID");

                    b.ToTable("Hotels", (string)null);

                    b.HasData(
                        new
                        {
                            HotelID = new Guid("60581ea7-a79e-4df4-abcb-a956f3316639"),
                            CreatedDate = new DateTime(2023, 3, 8, 12, 11, 4, 923, DateTimeKind.Local).AddTicks(1130),
                            LastUpdate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Hotel A"
                        });
                });

            modelBuilder.Entity("Hotel.Domain.Entities.Room", b =>
                {
                    b.Property<Guid>("RoomID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedDate");

                    b.Property<decimal>("DailyRate")
                        .HasColumnType("decimal")
                        .HasColumnName("DailyRate");

                    b.Property<Guid>("HotelID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit")
                        .HasColumnName("IsAvailable");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2")
                        .HasColumnName("LastUpdate");

                    b.Property<DateTime>("NextBookingAvailableDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("NextBookingAvailableDate");

                    b.Property<int>("Number")
                        .HasColumnType("integer")
                        .HasColumnName("Number");

                    b.HasKey("RoomID");

                    b.HasIndex("HotelID");

                    b.ToTable("Rooms", (string)null);

                    b.HasData(
                        new
                        {
                            RoomID = new Guid("31342b41-1dee-491a-8dd6-6c03af271b9b"),
                            CreatedDate = new DateTime(2023, 3, 8, 12, 11, 4, 923, DateTimeKind.Local).AddTicks(1752),
                            DailyRate = 100m,
                            HotelID = new Guid("60581ea7-a79e-4df4-abcb-a956f3316639"),
                            IsAvailable = false,
                            LastUpdate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NextBookingAvailableDate = new DateTime(2023, 3, 11, 12, 11, 4, 923, DateTimeKind.Local).AddTicks(1755),
                            Number = 1
                        },
                        new
                        {
                            RoomID = new Guid("c6643f13-4937-4014-9730-5e444efac094"),
                            CreatedDate = new DateTime(2023, 3, 8, 12, 11, 4, 923, DateTimeKind.Local).AddTicks(1760),
                            DailyRate = 100m,
                            HotelID = new Guid("60581ea7-a79e-4df4-abcb-a956f3316639"),
                            IsAvailable = false,
                            LastUpdate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NextBookingAvailableDate = new DateTime(2023, 3, 11, 12, 11, 4, 923, DateTimeKind.Local).AddTicks(1761),
                            Number = 2
                        },
                        new
                        {
                            RoomID = new Guid("b6172848-ad8f-4a60-8fbd-4b69a7226732"),
                            CreatedDate = new DateTime(2023, 3, 8, 12, 11, 4, 923, DateTimeKind.Local).AddTicks(1764),
                            DailyRate = 100m,
                            HotelID = new Guid("60581ea7-a79e-4df4-abcb-a956f3316639"),
                            IsAvailable = false,
                            LastUpdate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NextBookingAvailableDate = new DateTime(2023, 3, 11, 12, 11, 4, 923, DateTimeKind.Local).AddTicks(1765),
                            Number = 3
                        },
                        new
                        {
                            RoomID = new Guid("d5c82e94-c3af-4780-8d73-8b05ee00a683"),
                            CreatedDate = new DateTime(2023, 3, 8, 12, 11, 4, 923, DateTimeKind.Local).AddTicks(1768),
                            DailyRate = 100m,
                            HotelID = new Guid("60581ea7-a79e-4df4-abcb-a956f3316639"),
                            IsAvailable = false,
                            LastUpdate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NextBookingAvailableDate = new DateTime(2023, 3, 11, 12, 11, 4, 923, DateTimeKind.Local).AddTicks(1769),
                            Number = 4
                        },
                        new
                        {
                            RoomID = new Guid("780c62af-43c2-4a67-820c-1d6c38409249"),
                            CreatedDate = new DateTime(2023, 3, 8, 12, 11, 4, 923, DateTimeKind.Local).AddTicks(1776),
                            DailyRate = 100m,
                            HotelID = new Guid("60581ea7-a79e-4df4-abcb-a956f3316639"),
                            IsAvailable = true,
                            LastUpdate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NextBookingAvailableDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Number = 5
                        });
                });

            modelBuilder.Entity("Hotel.Domain.Entities.Booking", b =>
                {
                    b.HasOne("Hotel.Domain.Entities.Customer", "Customer")
                        .WithMany("Bookings")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hotel.Domain.Entities.Hotel", null)
                        .WithMany("Bookings")
                        .HasForeignKey("HotelID");

                    b.HasOne("Hotel.Domain.Entities.Room", "Room")
                        .WithMany("Bookings")
                        .HasForeignKey("RoomID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Hotel.Domain.Entities.Room", b =>
                {
                    b.HasOne("Hotel.Domain.Entities.Hotel", "Hotel")
                        .WithMany("Rooms")
                        .HasForeignKey("HotelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("Hotel.Domain.Entities.Customer", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("Hotel.Domain.Entities.Hotel", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("Hotel.Domain.Entities.Room", b =>
                {
                    b.Navigation("Bookings");
                });
#pragma warning restore 612, 618
        }
    }
}
