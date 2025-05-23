using Microsoft.EntityFrameworkCore;

namespace MyInventoryApp.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }      // 👈 Add this
        public DbSet<Order> Orders { get; set; }    // 👈 And this

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(18, 2); // Keep precision for decimals
        }
    }
}