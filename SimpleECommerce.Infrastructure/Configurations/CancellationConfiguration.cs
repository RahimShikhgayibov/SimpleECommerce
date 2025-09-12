using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleECommerce.Domain.Entities;

namespace SimpleECommerce.Infrastructure.Configurations;

public class CancellationConfiguration : IEntityTypeConfiguration<Cancellation>
{
    public void Configure(EntityTypeBuilder<Cancellation> builder)
    {
        builder.ToTable("cancellations");

        builder.HasKey(c => c.Id)
            .HasName("pk_cancellations");
        
        builder.Property(c => c.Id)
            .HasColumnName("id")
            .IsRequired();

        builder.Property(c => c.OrderId)
            .HasColumnName("order_id")
            .IsRequired();
        
        builder.HasOne(c => c.Order)
            .WithOne(o => o.Cancellation)
            .HasForeignKey<Cancellation>(c => c.OrderId)
            .HasConstraintName("fk_cancellations_order_id")
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.Property(e => e.Reason)
            .IsRequired()
            .HasColumnName("type");
        
        builder.Property(e => e.Status)
            .IsRequired()
            .HasColumnName("type");
        builder.Property(e => e.OrderAmount)
            .IsRequired()
            .HasColumnName("type");
        
        builder.Property(e => e.CancellationCharges)
            .IsRequired()
            .HasColumnName("type");
        
    }
}