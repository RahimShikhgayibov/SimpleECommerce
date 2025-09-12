using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleECommerce.Domain.Entities;

namespace SimpleECommerce.Infrastructure.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("roles");

        builder.HasKey(e => e.Id)
            .HasName("pk_roles");

        builder.HasIndex(e => e.Name)
            .IsUnique()
            .HasDatabaseName("uk_roles_name");

        builder.Property(e => e.Id)
            .IsRequired()
            .HasColumnName("id");

        builder.Property(e => e.Name)
            .IsRequired()
            .HasColumnName("name");

        builder.Property(e => e.Description)
            .HasColumnName("description");

        builder.Property(e => e.IsDefault)
            .IsRequired()
            .HasDefaultValue(false)
            .HasColumnName("is_default");

        builder.Property(e => e.IsEditable)
            .IsRequired()
            .HasColumnName("is_editable")
            .HasDefaultValue(false);

        builder.Property(e => e.IsActive)
            .IsRequired()
            .HasColumnName("is_active")
            .HasDefaultValue(true);

        builder.Property(e => e.CreationTime)
            .HasColumnName("creation_time")
            .IsRequired();

        builder.Property(e => e.CreatorUserId)
            .HasColumnName("creator_user_id")
            .IsRequired();

        builder.Property(e => e.LastModificationTime)
            .HasColumnName("last_modification_time");

        builder.Property(e => e.LastModifierUserId)
            .HasColumnName("last_modifier_user_id");
    }
}