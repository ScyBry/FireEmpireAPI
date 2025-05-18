using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class EventProductUsageConfiguration : IEntityTypeConfiguration<EventProductUsage>
    {
        public void Configure(EntityTypeBuilder<EventProductUsage> builder)
        {

            builder.HasKey(e => e.Id);
            builder.Property(e => e.IsDeleted).HasDefaultValue(false);


            builder.Property(e => e.QuantityUsed)
                .IsRequired();

            builder.Property(e => e.UsageDate)
                .IsRequired();

            builder.Property(e => e.IsReturned)
                .HasDefaultValue(false);


            builder.HasOne(e => e.Event)
                   .WithMany(e => e.ProductUsages)
                   .HasForeignKey(e => e.EventId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Product)
                   .WithMany(p => p.ProductUsages)
                   .HasForeignKey(e => e.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Warehouse)
                   .WithMany(w => w.ProductUsages)
                   .HasForeignKey(e => e.WarehouseId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
