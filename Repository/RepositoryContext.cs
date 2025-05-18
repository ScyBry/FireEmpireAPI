using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;


namespace Repository
{
    public class RepositoryContext : DbContext
    {




        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ContactConfiguration());
            modelBuilder.ApplyConfiguration(new EventConfiguration());
            modelBuilder.ApplyConfiguration(new EventProductUsageConfiguration());
            modelBuilder.ApplyConfiguration(new ProductCategoryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProductEntityConfiguration());
            modelBuilder.ApplyConfiguration(new WarehouseConfiguration());
            modelBuilder.ApplyConfiguration(new WarehouseProductConfiguration());
        }



        public DbSet<ContactEntity>? Contacts { get; set; }
        public DbSet<Event>? Events { get; set; }
        public DbSet<EventProductUsage>? EventProductUsages { get; set; }
        public DbSet<ProductCategoryEntity>? ProductCategories { get; set; }
        public DbSet<ProductEntity>? Products { get; set; }
        public DbSet<Warehouse>? Warehouses { get; set; }
        public DbSet<WarehouseProduct>? WarehouseProducts { get; set; }




    }
}