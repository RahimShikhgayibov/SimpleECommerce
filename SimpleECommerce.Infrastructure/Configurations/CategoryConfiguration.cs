using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleECommerce.Domain.Entities;

namespace SimpleECommerce.Infrastructure.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("categories");

        builder
            .HasKey(c => c.Id)
            .HasName("pk_categories");
        
        builder.Property(c => c.Id)
            .HasColumnName("id")
            .IsRequired();
        
        builder.Property(c => c.Name)
            .HasColumnName("name").IsRequired();
        
        builder.Property(c => c.Description)
            .HasColumnName("description");//limit
        
        builder.Property(c => c.IsActive)
            .HasColumnName("is_active")
            .HasDefaultValue(true);
        
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