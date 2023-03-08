using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities = Hotel.Domain.Entities;

namespace Hotel.Infra.Repository.Mapping
{
    public class HotelConfiguration : IEntityTypeConfiguration<Entities.Hotel>
    {
        public void Configure(EntityTypeBuilder<Entities.Hotel> builder)
        {
            builder.HasKey(h => h.HotelID);

            builder.Property(h => h.Name)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(h => h.CreatedDate)
                .IsRequired()
                .HasColumnName("CreatedDate")
                .HasColumnType("datetime2");

            builder.Property(h => h.LastUpdate)
                .HasColumnName("LastUpdate")
                .HasColumnType("datetime2");

            builder.HasMany(h => h.Rooms)
                .WithOne(r => r.Hotel)
                .HasForeignKey(r => r.HotelID);

            builder.ToTable("Hotels");
        }
    }
}