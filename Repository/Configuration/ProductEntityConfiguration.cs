using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class ProductEntityConfiguration : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.ProductName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(p => p.ProductPrice)
                   .HasColumnType("decimal(18,2)");

            builder.HasOne(p => p.Category)
                   .WithMany(c => c.Products)
                   .HasForeignKey(p => p.CategoryId);

            builder.HasMany(p => p.WarehouseProducts)
                   .WithOne(wp => wp.Product)
                   .HasForeignKey(wp => wp.ProductId);

            builder.HasMany(p => p.ProductUsages)
                   .WithOne(epu => epu.Product)
                   .HasForeignKey(epu => epu.ProductId);
        }
    }
}
