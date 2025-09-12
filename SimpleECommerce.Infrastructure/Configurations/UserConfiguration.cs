using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleECommerce.Domain.Entities;

namespace SimpleECommerce.Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder.HasKey(e => e.Id)
            .HasName("pk_users");

        builder.HasIndex(e => e.EmailAddress)
            .IsUnique()
            .HasDatabaseName("uk_users_email_address");

        builder.HasIndex(e => e.UserName)
            .IsUnique()
            .HasDatabaseName("uk_users_user_name");

        builder.HasOne(e => e.Role)
            .WithMany()
            .HasForeignKey(e => e.RoleId)
            .HasConstraintName("fk_users_role_id")
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(e => e.Id)
            .IsRequired()
            .HasColumnName("id");

        builder.Property(e => e.RoleId)
            .IsRequired()
            .HasColumnName("role_id");

        builder.Property(e => e.ImageName)
            .HasColumnName("image_name");

        builder.Property(e => e.ImageContentType)
            .HasColumnName("image_content_type");

        builder.Property(e => e.Name)
            .IsRequired()
            .HasColumnName("name");

        builder.Property(e => e.Name)
            .IsRequired()
            .HasColumnName("name");

        builder.Property(e => e.Surname)
            .HasColumnName("surname");

        builder.Property(e => e.PatronymicName)
            .IsRequired()
            .HasColumnName("patronymic_name");

        builder.Property(e => e.PinCode)
            .IsRequired()
            .HasColumnName("pin_code");

        builder.Property(e => e.Position)
            .IsRequired()
            .HasColumnName("position");

        builder.Property(e => e.EmailAddress)
            .IsRequired()
            .HasColumnName("email_address");

        builder.Property(e => e.Fax)
            .HasColumnName("fax");

        builder.Property(e => e.PhoneNumbers)
            .IsRequired()
            .HasColumnName("phone_numbers");

        builder.Property(e => e.UserName)
            .IsRequired()
            .HasColumnName("user_name");

        builder.Property(e => e.PasswordHash)
            .IsRequired()
            .HasColumnName("password_hash");

        builder.Property(e => e.SaltHash)
            .IsRequired()
            .HasColumnName("salt_hash");

        builder.Property(e => e.SecurityStamp)
            .IsRequired()
            .HasColumnName("security_stamp");

        builder.Property(e => e.RefreshToken)
            .HasColumnName("refresh_token");

        builder.Property(e => e.IsMailConfirmed)
            .IsRequired()
            .HasColumnName("is_mail_confirmed")
            .HasDefaultValue(true);

        builder.Property(e => e.IsDataConfirmed)
            .IsRequired()
            .HasColumnName("is_data_confirmed")
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