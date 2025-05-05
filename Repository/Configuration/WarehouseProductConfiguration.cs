using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class WarehouseProductConfiguration : IEntityTypeConfiguration<WarehouseProduct>
    {
        public void Configure(EntityTypeBuilder<WarehouseProduct> builder)
        {
            builder.HasKey(wp => wp.Id);

            builder.Property(wp => wp.TotalQuantity).IsRequired();
            builder.Property(wp => wp.ReservedQuantity).IsRequired();

            builder.HasOne(wp => wp.Product)
                   .WithMany(p => p.WarehouseProducts)
                   .HasForeignKey(wp => wp.ProductId);

            builder.HasOne(wp => wp.Warehouse)
                   .WithMany(w => w.WarehouseProducts)
                   .HasForeignKey(wp => wp.WarehouseId);
        }
    }
}
