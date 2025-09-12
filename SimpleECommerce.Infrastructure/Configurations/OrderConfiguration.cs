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

        // BillingAddress (many orders can reference same address) - no navigation back
        builder.HasOne(o => o.BillingAddress)
            .WithMany()
            .HasForeignKey(o => o.BillingAddressId)
            .OnDelete(DeleteBehavior.Restrict);

        // ShippingAddress
        builder.HasOne(o => o.ShippingAddress)
            .WithMany()
            .HasForeignKey(o => o.ShippingAddressId)
            .OnDelete(DeleteBehavior.Restrict);

        // Cancellation (one-to-one)
        builder.HasOne(o => o.Cancellation)
            .WithOne(c => c.Order)
            .HasForeignKey<Cancellation>(c => c.OrderId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}