using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleECommerce.Domain.Entities;

namespace SimpleECommerce.Infrastructure.Configurations;

public class FaqItemConfiguration : IEntityTypeConfiguration<FaqItem>
{
    public void Configure(EntityTypeBuilder<FaqItem> builder)
    {
        builder.ToTable("faq_items");

        builder.HasKey(e => e.Id)
            .HasName("pk_faq_items");

        builder.Property(e => e.Id)
            .IsRequired()
            .HasColumnName("id");
        
        builder.Property(e => e.Question)
            .IsRequired()
            .HasColumnName("question");

        builder.Property(e => e.Answer)
            .IsRequired()
            .HasColumnName("answer");
        
        builder.Property(e => e.IsDeleted)
            .IsRequired()
            .HasColumnName("is_deleted")
            .HasDefaultValue(false);
        
        builder.Property(e => e.DeletionTime)
            .HasColumnName("deletion_time");

        builder.Property(e => e.DeleterUserId)
            .HasColumnName("deleter_user_id");

        builder.Property(e => e.IsActive)
            .IsRequired()
            .HasColumnName("is_active")
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
    }
}