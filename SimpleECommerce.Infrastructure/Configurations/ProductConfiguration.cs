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
        
        builder.Property(p => p.Description).HasColumnName("description").IsRequired();
        
        builder.Property(p => p.Price).HasColumnName("price").HasColumnType("decimal(18,2)").IsRequired();
        
        builder.Property(p => p.StockQuantity).HasColumnName("stock_quantity").IsRequired();
        
        builder.Property(p => p.ImageUrl).HasColumnName("image_url").IsRequired();
        
        builder.Property(p => p.DiscountPercentage).HasColumnName("discount_percentage");
        
        builder.Property(p => p.CategoryId).HasColumnName("category_id");
        
        builder.HasOne(e => e.Category)
            .WithMany(e => e.Products)
            .HasForeignKey(e => e.CategoryId)
            .HasConstraintName("fk_products_category_id")
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.Property(p => p.IsActive)
            .HasColumnName("is_active")
            .HasDefaultValue(false);
        
        builder.Property(p => p.IsValid)
            .HasColumnName("is_valid")
            .HasDefaultValue(false);
        
        builder.Property(e => e.IsDeleted)
            .IsRequired()
            .HasColumnName("is_deleted")
            .HasDefaultValue(false);
        
        builder.Property(e => e.CreationTime)
            .IsRequired()
            .HasColumnName("creation_time");

        builder.Property(e => e.CreatorUserId)
            .IsRequired()
            .HasColumnName("creator_user_id");
        
        builder.Property(e => e.DeletionTime)
            .IsRequired(false)
            .HasColumnName("deletion_time");

        builder.Property(e => e.DeleterUserId)
            .IsRequired(false)
            .HasColumnName("deleter_user_id");
        
        builder.Property(e => e.LastModificationTime)
            .IsRequired(false)
            .HasColumnName("modification_time");

        builder.Property(e => e.LastModifierUserId)
            .IsRequired(false)
            .HasColumnName("modifier_user_id");
    }
}
