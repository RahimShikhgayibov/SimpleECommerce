using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleECommerce.Domain.Entities;

namespace SimpleECommerce.Infrastructure.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("orders");

        builder.HasKey(o => o.Id).HasName("pk_orders");

        builder.Property(o => o.Id).HasColumnName("id").IsRequired();
        
        builder.Property(a => a.OrderNumber)
            .IsRequired()
            .HasColumnName("order_number");
        
        builder.Property(x => x.UserId)
            .HasColumnName("user_id");
        
        builder.HasOne(e => e.User)
            .WithMany(e => e.Orders)
            .HasForeignKey(e => e.UserId)
            .HasConstraintName("fk_orders_user_id")
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.Property(x => x.BillingAddressId)
            .HasColumnName("billing_address_id");
        
        builder.HasOne(o => o.BillingAddress)
            .WithMany()
            .HasForeignKey(o => o.BillingAddressId)
            .HasConstraintName("fk_orders_billing_address_id")
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.ShippingAddressId)
            .HasColumnName("shipping_address_id");
        
        builder.HasOne(o => o.ShippingAddress)
            .WithMany()
            .HasForeignKey(o => o.ShippingAddressId)
            .HasConstraintName("fk_orders_shipping_address_id")
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(a => a.TotalBaseAmount)
            .IsRequired()
            .HasColumnName("total_base_amount");
        
        builder.Property(a => a.TotalAmount)
            .IsRequired()
            .HasColumnName("total_amount");
        
        builder.Property(a => a.TotalDiscountAmount)
            .IsRequired()
            .HasColumnName("total_discount_amount");
        
        builder.Property(a => a.ShippingCost)
            .IsRequired()
            .HasColumnName("shipping_cost");
        
        builder.Property(a => a.OrderStatus)
            .IsRequired()
            .HasColumnName("order_status");
        
        builder.HasOne(o => o.Cancellation)
            .WithOne(c => c.Order)
            .HasForeignKey<Cancellation>(c => c.OrderId)
            .OnDelete(DeleteBehavior.Restrict);
        
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