using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleECommerce.Domain.Entities;

namespace SimpleECommerce.Infrastructure.Configurations;

public class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
{
    public void Configure(EntityTypeBuilder<RolePermission> builder)
    {
        builder.ToTable("role_permissions");

        builder.HasKey(e => e.Id)
            .HasName("pk_role_permissions");

        builder.HasIndex(e => new { e.RoleId, e.PermissionId })
            .IsUnique()
            .HasDatabaseName("uk_role_permissions_role_id_perm_id");

        builder.Property(e => e.Id)
            .IsRequired()
            .HasColumnName("id");

        builder.Property(e => e.RoleId)
            .IsRequired()
            .HasColumnName("role_id");

        builder.HasOne(e => e.Role)
            .WithMany(e => e.RolePermissions)
            .HasForeignKey(e => e.RoleId)
            .HasConstraintName("fk_role_permissions_role_id")
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.Property(e => e.PermissionId)
            .IsRequired()
            .HasColumnName("permission_id");

        builder.HasOne(e => e.Permission)
            .WithMany()
            .HasForeignKey(e => e.PermissionId)
            .HasConstraintName("fk_role_permissions_permission_id")
            .OnDelete(DeleteBehavior.Restrict);
    }
}