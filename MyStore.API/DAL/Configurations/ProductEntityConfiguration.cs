using MyStore.API.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace MyStore.API.DAL.Configurations
{
    public sealed class ProductEntityConfiguration : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ProductEntity> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(300);

            builder.Property(e => e.Description)
               .HasColumnType("nvarchar")
               .HasMaxLength(500);

            builder.Property(e => e.CategoryId)
                .IsRequired()
                .HasColumnType("uniqueidentifier")
                .HasMaxLength(300);

            builder.HasIndex(e => e.CategoryId);
        }
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(500);

            builder.Property(e => e.IsAdmin)
               .HasColumnType("bit");

        }
    }
}
