using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class WarehouseConfiguration : IEntityTypeConfiguration<Warehouse>
    {
        public void Configure(EntityTypeBuilder<Warehouse> builder)
        {

            builder.HasKey(w => w.Id);
            builder.Property(w => w.IsDeleted).HasDefaultValue(false);


            builder.Property(w => w.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(w => w.Location)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(w => w.ContactPerson)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(w => w.PhoneNumber)
                   .IsRequired()
                   .HasMaxLength(20);


            builder.HasMany(w => w.WarehouseProducts)
                   .WithOne(wp => wp.Warehouse)
                   .HasForeignKey(wp => wp.WarehouseId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(w => w.ProductUsages)
                   .WithOne(epu => epu.Warehouse)
                   .HasForeignKey(epu => epu.WarehouseId)
                   .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
