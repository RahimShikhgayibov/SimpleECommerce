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
            .HasColumnName("reason");
        
        builder.Property(e => e.Status)
            .IsRequired()
            .HasColumnName("status");
        
        builder.Property(e => e.OrderAmount)
            .IsRequired()
            .HasColumnName("order_amount");
        
        builder.Property(e => e.CancellationCharges)
            .HasColumnName("cancellation_charges")
            .IsRequired()
            .HasColumnType("decimal(18,2)")
            .HasDefaultValue(0.00m);
        
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