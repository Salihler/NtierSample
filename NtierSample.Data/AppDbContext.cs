using Microsoft.EntityFrameworkCore;
using NtierSample.Core.Models;
using NtierSample.Data.Configurations;
using NtierSample.Data.Seeds;

namespace NtierSample.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());

            modelBuilder.ApplyConfiguration(new ProductSeeds(new int[]{1,2}));
            modelBuilder.ApplyConfiguration(new CategorySeeds(new int[]{1,2}));
        }
    }
}