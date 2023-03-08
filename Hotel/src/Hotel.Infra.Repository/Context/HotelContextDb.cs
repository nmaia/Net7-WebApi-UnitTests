using Hotel.Infra.Repository.DataSeed;
using Hotel.Infra.Repository.Mapping;
using Microsoft.EntityFrameworkCore;
using Entities = Hotel.Domain.Entities;

namespace Hotel.Infra.Repository.Context
{
    public class HotelContextDb : DbContext
    {
        public HotelContextDb(DbContextOptions<HotelContextDb> options)
            : base(options)
        {

        }

        public DbSet<Entities.Hotel> Hotels { get; set; }
        public DbSet<Entities.Booking> Bookings { get; set; }
        public DbSet<Entities.Room> Rooms { get; set; }
        public DbSet<Entities.Customer> Customers { get; set; }        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new HotelConfiguration());
            modelBuilder.ApplyConfiguration(new RoomConfiguration());
            modelBuilder.ApplyConfiguration(new BookingConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());

            modelBuilder.StartDataSeed();

            base.OnModelCreating(modelBuilder);
        }
    }
}
