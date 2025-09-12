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

        // Payment -> Refund (one-to-one)
        builder.HasOne(p => p.Refund)
            .WithOne(r => r.Payment)
            .HasForeignKey<Refund>(r => r.PaymentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}