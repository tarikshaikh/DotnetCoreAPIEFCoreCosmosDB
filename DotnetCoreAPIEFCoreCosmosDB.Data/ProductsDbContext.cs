using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace DotnetCoreAPIEFCoreCosmosDB.Data
{
    public class ProductsDbContext : DbContext
    {
        public ProductsDbContext()
        {
        }

        public ProductsDbContext(DbContextOptions<ProductsDbContext> options): base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .ToContainer("Products");

            modelBuilder.Entity<Product>()
                .Property(x => x.id)
                .HasConversion<string>()
                .HasValueGenerator<SequentialGuidValueGenerator>();

            modelBuilder.Entity<Product>()
                .HasPartitionKey(nameof(Product.id));
        }
    }
}
