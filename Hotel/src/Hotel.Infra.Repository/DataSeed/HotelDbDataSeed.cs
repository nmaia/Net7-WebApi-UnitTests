using Microsoft.EntityFrameworkCore;
using Entities = Hotel.Domain.Entities;

namespace Hotel.Infra.Repository.DataSeed
{
    public static class HotelDbDataSeed
    {
        public static readonly Guid HotelID_1 = Guid.NewGuid();
         
        public static readonly Guid CustomerID_1 = Guid.NewGuid();
        public static readonly Guid CustomerID_2 = Guid.NewGuid();
        public static readonly Guid CustomerID_3 = Guid.NewGuid();
        public static readonly Guid CustomerID_4 = Guid.NewGuid();
        public static readonly Guid CustomerID_5 = Guid.NewGuid();
         
        public static readonly Guid BookingID_1 = Guid.NewGuid();
        public static readonly Guid BookingID_2 = Guid.NewGuid();
        public static readonly Guid BookingID_3 = Guid.NewGuid();
        public static readonly Guid BookingID_4 = Guid.NewGuid();
         
        public static readonly Guid RoomID_1 = Guid.NewGuid();
        public static readonly Guid RoomID_2 = Guid.NewGuid();
        public static readonly Guid RoomID_3 = Guid.NewGuid();
        public static readonly Guid RoomID_4 = Guid.NewGuid();
        public static readonly Guid RoomID_5 = Guid.NewGuid();

        public static ModelBuilder StartDataSeed(this ModelBuilder builder)
        {
            builder.Entity<Entities.Hotel>().HasData(
                new Entities.Hotel { HotelID = HotelID_1, Name = "Hotel A", CreatedDate = DateTime.Now, LastUpdate = DateTime.MinValue }
            );

            builder.Entity<Entities.Customer>().HasData(
                new Entities.Customer { CustomerID = CustomerID_1, Name = "Zakk Wylde", BirthDate = DateTime.Parse("1967-01-14"), Email = "zakk@mail.com", SIN = 123456789, CreatedDate = DateTime.Now, LastUpdate = DateTime.MinValue },
                new Entities.Customer { CustomerID = CustomerID_2, Name = "Ozzy Osbourne", BirthDate = DateTime.Parse("1948-12-03"), Email = "ozzy@mail.com", SIN = 987654321, CreatedDate = DateTime.Now, LastUpdate = DateTime.MinValue },
                new Entities.Customer { CustomerID = CustomerID_3, Name = "Randy Blythe", BirthDate = DateTime.Parse("1971-02-21"), Email = "randy@mail.com", SIN = 111456222, CreatedDate = DateTime.Now, LastUpdate = DateTime.MinValue },
                new Entities.Customer { CustomerID = CustomerID_4, Name = "Ronnie James Dio", BirthDate = DateTime.Parse("1942-07-10"), Email = "dio@mail.com", SIN = 222456333, CreatedDate = DateTime.Now, LastUpdate = DateTime.MinValue },
                new Entities.Customer { CustomerID = CustomerID_5, Name = "James Hetfield", BirthDate = DateTime.Parse("1963-08-03"), Email = "james@mail.com", SIN = 333456444, CreatedDate = DateTime.Now, LastUpdate = DateTime.MinValue }
            );

            builder.Entity<Entities.Booking>().HasData(
                new Entities.Booking { BookingID = BookingID_1, CheckinDate = DateTime.Now.AddDays(1), CheckoutDate = DateTime.Now.AddDays(2), CreatedDate = DateTime.Now, LastUpdate = DateTime.MinValue, CustomerID = CustomerID_1, RoomID = RoomID_1, TotalCost = 100 },
                new Entities.Booking { BookingID = BookingID_2, CheckinDate = DateTime.Now.AddDays(1), CheckoutDate = DateTime.Now.AddDays(2), CreatedDate = DateTime.Now, LastUpdate = DateTime.MinValue, CustomerID = CustomerID_2, RoomID = RoomID_2, TotalCost = 100 },
                new Entities.Booking { BookingID = BookingID_3, CheckinDate = DateTime.Now.AddDays(1), CheckoutDate = DateTime.Now.AddDays(2), CreatedDate = DateTime.Now, LastUpdate = DateTime.MinValue, CustomerID = CustomerID_3, RoomID = RoomID_3, TotalCost = 100 },
                new Entities.Booking { BookingID = BookingID_4, CheckinDate = DateTime.Now.AddDays(1), CheckoutDate = DateTime.Now.AddDays(2), CreatedDate = DateTime.Now, LastUpdate = DateTime.MinValue, CustomerID = CustomerID_4, RoomID = RoomID_4, TotalCost = 100 }
            );

            builder.Entity<Entities.Room>().HasData(
                new Entities.Room { RoomID = RoomID_1, IsAvailable = false, Number = 1, DailyRate = 100, CreatedDate = DateTime.Now, LastUpdate = DateTime.MinValue, HotelID = HotelID_1, NextBookingAvailableDate = DateTime.Now.AddDays(3) },
                new Entities.Room { RoomID = RoomID_2, IsAvailable = false, Number = 2, DailyRate = 100, CreatedDate = DateTime.Now, LastUpdate = DateTime.MinValue, HotelID = HotelID_1, NextBookingAvailableDate = DateTime.Now.AddDays(3) },
                new Entities.Room { RoomID = RoomID_3, IsAvailable = false, Number = 3, DailyRate = 100, CreatedDate = DateTime.Now, LastUpdate = DateTime.MinValue, HotelID = HotelID_1, NextBookingAvailableDate = DateTime.Now.AddDays(3) },
                new Entities.Room { RoomID = RoomID_4, IsAvailable = false, Number = 4, DailyRate = 100, CreatedDate = DateTime.Now, LastUpdate = DateTime.MinValue, HotelID = HotelID_1, NextBookingAvailableDate = DateTime.Now.AddDays(3) },
                new Entities.Room { RoomID = RoomID_5, IsAvailable = true, Number = 5, DailyRate = 100, CreatedDate = DateTime.Now, LastUpdate = DateTime.MinValue, HotelID = HotelID_1, NextBookingAvailableDate = DateTime.MinValue }
            );

            return builder;
        }
    }
}
