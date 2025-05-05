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

            builder.HasOne(e => e.Event)
                   .WithMany(e => e.ProductUsages)
                   .HasForeignKey(e => e.EventId);

            builder.HasOne(e => e.Product)
                   .WithMany(p => p.ProductUsages)
                   .HasForeignKey(e => e.ProductId);

            builder.HasOne(e => e.Warehouse)
                   .WithMany(w => w.ProductUsages)
                   .HasForeignKey(e => e.WarehouseId);
        }
    }
}
