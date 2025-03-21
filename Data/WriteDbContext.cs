using Microsoft.EntityFrameworkCore;
using OrderManagement.Models;

namespace OrderManagement.Data
{
    public class WriteDbContext : DbContext
    {
        public DbSet<Order> Orders => Set<Order>();

        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasKey(o => o.Id);
        }
    }
}
