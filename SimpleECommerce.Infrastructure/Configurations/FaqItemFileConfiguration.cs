using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleECommerce.Domain.Entities;

namespace SimpleECommerce.Infrastructure.Configurations;

public class FaqItemFileConfiguration : IEntityTypeConfiguration<FaqItemFile>
{
    public void Configure(EntityTypeBuilder<FaqItemFile> builder)
    {
        builder.ToTable("faq_item_files");
        
        builder.HasKey(x => x.Id)
            .HasName("pk_faq_item_files");
        
        builder.HasOne(e => e.FaqItem)
            .WithMany(e => e.FaqItemFiles)
            .HasForeignKey(e => e.FaqItemId)
            .HasConstraintName("fk_faq_item_files_faq_item_id")
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.Property(e => e.Id)
            .IsRequired()
            .HasColumnName("id");
        
        builder.Property(e => e.FaqItemId)
            .IsRequired()
            .HasColumnName("faq_item_id");

        builder.Property(e => e.FileOriginalName)
            .IsRequired()
            .HasColumnName("file_original_name")
            .HasMaxLength(300);

        builder.Property(e => e.FileName)
            .IsRequired()
            .HasColumnName("file_name")
            .HasMaxLength(100);

        builder.Property(e => e.FileContentType)
            .IsRequired()
            .HasColumnName("file_content_type")
            .HasMaxLength(100);

        builder.Property(e => e.Description)
            .HasColumnName("description")
            .HasMaxLength(1000);
        
        builder.Property(e => e.IsDeleted)
            .IsRequired()
            .HasColumnName("is_deleted")
            .HasDefaultValue(false);
        
        builder.Property(e => e.DeletionTime)
            .HasColumnName("deletion_time");

        builder.Property(e => e.DeleterUserId)
            .HasColumnName("deleter_user_id");

        builder.Property(e => e.CreationTime)
            .IsRequired()
            .HasColumnName("creation_time");

        builder.Property(e => e.CreatorUserId)
            .IsRequired()
            .HasColumnName("creator_user_id");
    }
}