using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleECommerce.Domain.Entities;

namespace SimpleECommerce.Infrastructure.Configurations;

public class UserSessionConfiguration : IEntityTypeConfiguration<UserSession>
{
    public void Configure(EntityTypeBuilder<UserSession> builder)
    {
        builder.ToTable("user_sessions");

        builder.HasKey(e => e.Id)
            .HasName("pk_user_sessions");

        builder.HasOne(e => e.User)
            .WithMany()
            .HasForeignKey(e => e.UserId)
            .HasConstraintName("fk_user_sessions_user_id")
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(e => e.Id)
            .IsRequired()
            .HasColumnName("id");

        builder.Property(e => e.UserId)
            .IsRequired()
            .HasColumnName("user_id");

        builder.Property(e => e.SessionType)
            .IsRequired()
            .HasColumnName("session_type");

        builder.Property(e => e.ActionDate)
            .IsRequired()
            .HasColumnName("action_date");

        builder.Property(e => e.Details)
            .HasColumnType("jsonb")
            .HasColumnName("details");
    }
}