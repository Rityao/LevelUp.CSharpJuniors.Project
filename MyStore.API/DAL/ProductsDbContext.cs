using MyStore.API.DAL.Configurations;
using MyStore.API.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace MyStore.API.DAL
{
    public sealed class ProductsDbContext : DbContext
    {
        public DbSet<ProductEntity>? Products { get; set; }
        public DbSet<UserEntity>? Users { get; set; }

        public ProductsDbContext(DbContextOptions<ProductsDbContext> options) : base(options)
        {

        }
         
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductEntityConfiguration());
        }
    }
}