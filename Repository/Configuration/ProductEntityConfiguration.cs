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
            builder.Property(p => p.IsDeleted).HasDefaultValue(false);


            builder.Property(p => p.ProductName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(p => p.ProductPrice)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.Property(p => p.VideoUrl)
                   .HasMaxLength(255);

            builder.Property(p => p.HazardClass)
                   .IsRequired()
                   .HasConversion<int>();

            builder.HasOne(p => p.Category)
                   .WithMany(c => c.Products)
                   .HasForeignKey(p => p.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.WarehouseProducts)
                   .WithOne(wp => wp.Product)
                   .HasForeignKey(wp => wp.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.ProductUsages)
                   .WithOne(epu => epu.Product)
                   .HasForeignKey(epu => epu.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
