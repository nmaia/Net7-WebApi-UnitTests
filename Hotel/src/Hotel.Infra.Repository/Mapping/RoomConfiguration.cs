using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities = Hotel.Domain.Entities;

namespace Hotel.Infra.Repository.Mapping
{
    public class RoomConfiguration : IEntityTypeConfiguration<Entities.Room>
    {
        public void Configure(EntityTypeBuilder<Entities.Room> builder)
        {
            builder.HasKey(r => r.RoomID);

            builder.Property(r => r.Number)
                .IsRequired()
                .HasColumnName("Number")
                .HasColumnType("integer");

            builder.Property(r => r.IsAvailable)
                .IsRequired()
                .HasColumnName("IsAvailable")
                .HasColumnType("bit");

            builder.Property(r => r.CreatedDate)
                .IsRequired()
                .HasColumnName("CreatedDate")
                .HasColumnType("datetime2");

            builder.Property(r => r.LastUpdate)
                .HasColumnName("LastUpdate")
                .HasColumnType("datetime2");

            builder.Property(r => r.DailyRate)
                .IsRequired()
                .HasColumnName("DailyRate")
                .HasColumnType("decimal");

            builder.Property(r => r.NextBookingAvailableDate)
                .IsRequired()
                .HasColumnName("NextBookingAvailableDate")
                .HasColumnType("datetime2");

            builder.HasMany(r => r.Bookings)
                .WithOne(b => b.Room)
                .HasForeignKey(b => b.RoomID);

            builder.HasOne(r => r.Hotel)
                .WithMany(h => h.Rooms)
                .HasForeignKey(r => r.HotelID);

            builder.ToTable("Rooms");
        }
    }
}
