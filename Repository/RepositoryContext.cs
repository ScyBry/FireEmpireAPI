using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class RepositoryContext : DbContext
    {
        public DbSet<Project>? Projects { get; set; }
        public DbSet<Firework>? Fireworks { get; set; }
        public DbSet<Event>? Events { get; set; }
        public DbSet<Category>? Categories { get; set; }



        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventFirework>()
        .HasKey(ef => new { ef.EventId, ef.FireworkId });

            modelBuilder.Entity<EventFirework>()
                .HasOne(ef => ef.Event)
                .WithMany(e => e.EventFireworks)
                .HasForeignKey(ef => ef.EventId);

            modelBuilder.Entity<EventFirework>()
                .HasOne(ef => ef.Firework)
                .WithMany(f => f.EventFireworks)
                .HasForeignKey(ef => ef.FireworkId);

        }




    }
}