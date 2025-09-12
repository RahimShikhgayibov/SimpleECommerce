using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleECommerce.Domain.Entities;

namespace SimpleECommerce.Infrastructure.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("products");

        builder.HasKey(p => p.Id).HasName("pk_products");
        builder.Property(p => p.Id).HasColumnName("id").IsRequired();
        builder.Property(p => p.Name).HasColumnName("name").IsRequired();
        builder.Property(p => p.Description).HasColumnName("description");
        builder.Property(p => p.Price).HasColumnName("price").HasColumnType("decimal(18,2)");
        builder.Property(p => p.StockQuantity).HasColumnName("stock_quantity");
        builder.Property(p => p.ImageUrl).HasColumnName("image_url");
        builder.Property(p => p.DiscountPercentage).HasColumnName("discount_percentage");
        builder.Property(p => p.CategoryId).HasColumnName("category_id");
        builder.Property(p => p.IsAvailable).HasColumnName("is_available");

        builder.HasData(
            new Product
            {
                Id = 1,
                Name = "Smartphone",
                Description = "Latest model smartphone with advanced features.",
                Price = 699.99m,
                StockQuantity = 50,
                ImageUrl = "https://example.com/images/smartphone.jpg",
                DiscountPercentage = 10,
                CategoryId = 1,
                IsAvailable = true
            },
            new Product
            {
                Id = 2,
                Name = "Laptop",
                Description = "High-performance laptop suitable for all your needs.",
                Price = 999.99m,
                StockQuantity = 30,
                ImageUrl = "https://example.com/images/laptop.jpg",
                DiscountPercentage = 15,
                CategoryId = 1,
                IsAvailable = true
            },
            new Product
            {
                Id = 3,
                Name = "Science Fiction Novel",
                Description = "A thrilling science fiction novel set in the future.",
                Price = 19.99m,
                StockQuantity = 100,
                ImageUrl = "https://example.com/images/scifi-novel.jpg",
                DiscountPercentage = 5,
                CategoryId = 2,
                IsAvailable = true
            }
        );
    }
}
