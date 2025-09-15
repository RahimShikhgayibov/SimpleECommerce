using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleECommerce.Domain.Entities;

namespace SimpleECommerce.Infrastructure.Configurations;

public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
{
    public void Configure(EntityTypeBuilder<Feedback> builder)
    {
        builder.ToTable("feedbacks");

        builder.HasKey(f => f.Id).HasName("pk_feedbacks");
        
        builder.Property(f => f.Id).HasColumnName("id").IsRequired();

        builder.Property(x => x.UserId)
            .HasColumnName("user_id");
        
        builder.HasOne(e => e.User)
            .WithMany(e => e.Feedbacks)
            .HasForeignKey(e => e.UserId)
            .HasConstraintName("fk_feedbacks_user_id")
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.Property(x => x.ProductId)
            .HasColumnName("product_id");
        
        builder.HasOne(e => e.Product)
            .WithMany(e => e.Feedbacks)
            .HasForeignKey(e => e.ProductId)
            .HasConstraintName("fk_feedbacks_product_id")
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.Property(e => e.Rating)
            .IsRequired(false)
            .HasColumnName("rating");
        
        builder.Property(e => e.Comment)
            .IsRequired(false)
            .HasColumnName("comment");
        
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