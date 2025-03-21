using Microsoft.EntityFrameworkCore;
using OrderManagement.Models;

namespace OrderManagement.Data
{
    public class ReadDbContext : DbContext
    {
        public DbSet<OrderDto> OrderDtos => Set<OrderDto>();

        public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDto>().HasKey(o => o.Id);
        }
    }
}
