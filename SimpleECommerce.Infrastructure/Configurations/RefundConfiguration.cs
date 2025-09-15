using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleECommerce.Domain.Entities;

namespace SimpleECommerce.Infrastructure.Configurations;

public class RefundConfiguration : IEntityTypeConfiguration<Refund>
{
    public void Configure(EntityTypeBuilder<Refund> builder)
    {
        builder.ToTable("refunds");

        builder.HasKey(r => r.Id).HasName("pk_refunds");
        builder.Property(r => r.Id).HasColumnName("id").IsRequired();

        builder.Property(r => r.PaymentId).HasColumnName("payment_id").IsRequired();

        builder.HasOne(r => r.Payment)
            .WithOne(p => p.Refund)
            .HasForeignKey<Refund>(r => r.PaymentId)
            .HasConstraintName("fk_refunds_payment_id")
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.Property(p => p.CancellationId).HasColumnName("cancellation_id").IsRequired();
        
        builder.HasOne(e => e.Cancellation)
            .WithOne(e => e.Refund)
            .HasForeignKey<Refund>(e => e.CancellationId)
            .HasConstraintName("fk_refunds_category_id")
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.Property(p => p.Amount).HasColumnName("amount").IsRequired();
        
        builder.Property(p => p.Status).HasColumnName("status").IsRequired();
        
        builder.Property(p => p.RefundMethod).HasColumnName("refund_method").IsRequired();
        
        builder.Property(p => p.RefundReason).HasColumnName("refund_reason").IsRequired();
        
        builder.Property(p => p.TransactionId).HasColumnName("transaction_id");
    }
}