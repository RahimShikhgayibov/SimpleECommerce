using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleECommerce.Domain.Entities;

namespace SimpleECommerce.Infrastructure.Configurations;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.ToTable("payments");

        builder.HasKey(p => p.Id).HasName("pk_payments");
        
        builder.Property(p => p.Id).HasColumnName("id").IsRequired();

        builder.Property(x => x.OrderId)
            .HasColumnName("order_id");
        
        builder.HasOne(e => e.Order)
            .WithOne(e => e.Payment)
            .HasForeignKey<Payment>(e => e.OrderId)
            .HasConstraintName("fk_payments_order_id")
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.Property(a => a.PaymentMethod)
            .IsRequired()
            .HasColumnName("payment_method");
        
        builder.Property(a => a.TransactionId)
            .IsRequired(false)
            .HasColumnName("transaction_id");
        
        builder.Property(a => a.Amount)
            .IsRequired()
            .HasColumnName("amount");
        
        builder.Property(a => a.Status)
            .IsRequired()
            .HasColumnName("status");
        
        builder.Property(e => e.CreationTime)
            .IsRequired()
            .HasColumnName("creation_time");

        builder.Property(e => e.CreatorUserId)
            .IsRequired()
            .HasColumnName("creator_user_id");
        
        
    }
}