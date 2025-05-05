using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.EventName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.EventDescription).HasMaxLength(500);
            builder.Property(e => e.Location).HasMaxLength(200);

            builder.HasMany(e => e.ProductUsages)
                   .WithOne(epu => epu.Event)
                   .HasForeignKey(epu => epu.EventId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
