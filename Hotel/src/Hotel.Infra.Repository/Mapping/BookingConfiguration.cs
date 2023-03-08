using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities = Hotel.Domain.Entities;

namespace Hotel.Infra.Repository.Mapping
{
    public class BookingConfiguration : IEntityTypeConfiguration<Entities.Booking>
    {
        public void Configure(EntityTypeBuilder<Entities.Booking> builder)
        {
            builder.HasKey(b => b.BookingID);

            builder.Property(b => b.CheckinDate)
                .IsRequired()
                .HasColumnName("CheckinDate")
                .HasColumnType("datetime2");

            builder.Property(b => b.CheckoutDate)
                .IsRequired()
                .HasColumnName("CheckoutDate")
                .HasColumnType("datetime2");

            builder.Property(b => b.CreatedDate)
                .IsRequired()
                .HasColumnName("CreatedDate")
                .HasColumnType("datetime2");

            builder.Property(b => b.LastUpdate)
                .HasColumnName("LastUpdate")
                .HasColumnType("datetime2");

            builder.Property(b => b.TotalCost)
                .IsRequired()
                .HasColumnName("TotalCost")
                .HasColumnType("decimal");

            builder.HasOne(b => b.Room)
                .WithMany(r => r.Bookings)
                .HasForeignKey(b => b.RoomID);

            builder.HasOne(b => b.Customer)
                .WithMany(c => c.Bookings)
                .HasForeignKey(b => b.CustomerID);

            builder.ToTable("Bookings");
        }
    }
}
