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
            .OnDelete(DeleteBehavior.Restrict);
    }
}