using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleECommerce.Domain.Entities;

namespace SimpleECommerce.Infrastructure.Configurations;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.ToTable("order_items");

        builder.HasKey(o => o.Id).HasName("pk_order_items");

        builder.Property(o => o.Id).HasColumnName("id").IsRequired();
        
        builder.Property(x => x.OrderId)
            .HasColumnName("order_id");
        
        builder.HasOne(e => e.Order)
            .WithMany(e => e.OrderItems)
            .HasForeignKey(e => e.OrderId)
            .HasConstraintName("fk_order_items_order_id")
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.Property(x => x.ProductId)
            .HasColumnName("product_id");
        
        builder.HasOne(o => o.Product)
            .WithMany(e=>e.OrderItems)
            .HasForeignKey(o => o.ProductId)
            .HasConstraintName("fk_order_items_product_id")
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.Property(a => a.Quantity)
            .IsRequired()
            .HasColumnName("quantity");
        
        builder.Property(a => a.UnitPrice)
            .IsRequired()
            .HasColumnName("unit_price");
        
        builder.Property(a => a.Discount)
            .IsRequired()
            .HasColumnName("discount");
        
        builder.Property(a => a.TotalPrice)
            .IsRequired()
            .HasColumnName("total_price");
        
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