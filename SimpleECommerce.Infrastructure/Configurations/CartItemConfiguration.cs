using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleECommerce.Domain.Entities;

namespace SimpleECommerce.Infrastructure.Configurations;

public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        builder.ToTable("cart_items");

        builder.HasKey(c => c.Id)
            .HasName("pk_cart_items");
        
        builder.Property(c => c.Id)
            .HasColumnName("id")
            .IsRequired();
        
        builder.Property(c => c.CartId)
            .HasColumnName("cart_id")
            .IsRequired();
        
        builder.HasOne(c => c.Cart)
            .WithMany(o => o.CartItems)
            .HasForeignKey(c => c.CartId)
            .HasConstraintName("fk_cancellations_cart_id")
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.Property(c => c.ProductId)
            .HasColumnName("product_id")
            .IsRequired();
        
        builder.HasOne(c => c.Product)
            .WithOne(o => o.CartItem)
            .HasForeignKey<CartItem>(c => c.ProductId)
            .HasConstraintName("fk_cancellations_cart_id")
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.Property(e => e.Quantity)
            .IsRequired()
            .HasColumnName("quantity");
        
        builder.Property(e => e.TotalPrice)
            .IsRequired()
            .HasColumnName("total_price");
        
        builder.Property(e => e.Discount)
            .IsRequired()
            .HasColumnName("discount");
        
        builder.Property(e => e.UnitPrice)
            .IsRequired()
            .HasColumnName("unit_price");
        
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
    }
}