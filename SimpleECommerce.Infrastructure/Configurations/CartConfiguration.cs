using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleECommerce.Domain.Entities;

namespace SimpleECommerce.Infrastructure.Configurations;

public class CartConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.ToTable("carts");

        builder.HasKey(a => a.Id)
            .HasName("pk_carts");
        
        builder.Property(e => e.Id)
            .IsRequired()
            .HasColumnName("id");
        
        builder.Property(c => c.UserId)
            .HasColumnName("user_id")
            .IsRequired();
        
        builder.HasOne(c => c.User)
            .WithMany(o => o.Carts)
            .HasForeignKey(c => c.UserId)
            .HasConstraintName("fk_carts_user_id")
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.Property(e => e.IsActive)
            .IsRequired()
            .HasColumnName("is_active")
            .HasDefaultValue(true);
        
        builder.Property(e => e.IsValid)
            .IsRequired()
            .HasColumnName("is_valid")
            .HasDefaultValue(true);
        
        builder.Property(e => e.CreationTime)
            .IsRequired()
            .HasColumnName("creation_time");

        builder.Property(e => e.CreatorUserId)
            .IsRequired()
            .HasColumnName("creator_user_id");

        builder.Property(e => e.LastModificationTime)
            .HasColumnName("last_modification_time");

        builder.Property(e => e.LastModifierUserId)
            .HasColumnName("last_modifier_user_id");
        
        builder.Property(e => e.IsDeleted)
            .IsRequired()
            .HasColumnName("is_deleted")
            .HasDefaultValue(false);
        
        builder.Property(e => e.DeletionTime)
            .IsRequired(false)
            .HasColumnName("deletion_time");

        builder.Property(e => e.DeleterUserId)
            .IsRequired(false)
            .HasColumnName("deleter_user_id");
    }
}