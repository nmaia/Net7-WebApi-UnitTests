using Hotel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities = Hotel.Domain.Entities;

namespace Hotel.Infra.Repository.Mapping
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Entities.Customer>
    {
        public void Configure(EntityTypeBuilder<Entities.Customer> builder)
        {
            builder.HasKey(c => c.CustomerID);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Email)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType("varchar(100)");

            builder.Property(c => c.BirthDate)
                .IsRequired()
                .HasColumnName("BirthDate")
                .HasColumnType("date");

            builder.Property(c => c.SIN)
                .IsRequired()
                .HasColumnName("SIN")
                .HasColumnType("integer")
                .HasMaxLength(9);

            builder.Property(c => c.CreatedDate)
                .IsRequired()
                .HasColumnName("CreatedDate")
                .HasColumnType("datetime2");

            builder.Property(c => c.LastUpdate)
                .HasColumnName("LastUpdate")
                .HasColumnType("datetime2");

            builder.HasMany(c => c.Bookings)
                .WithOne(b => b.Customer)
                .HasForeignKey(b => b.CustomerID);

            builder.ToTable("Customers");
        }
    }
}
