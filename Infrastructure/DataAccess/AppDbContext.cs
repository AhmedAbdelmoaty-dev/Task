using Microsoft.EntityFrameworkCore;
using Domain.Entites;

namespace Infrastructure.DataAccess
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
        public DbSet<Product>Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasQueryFilter(x => !x.IsDeleted);

            modelBuilder.Entity<Product>().HasIndex(x => x.Sku).IsUnique();

            modelBuilder.Entity<Product>().Property(x => x.Price).HasColumnType("decimal(8,2)");
        }
    }
}
