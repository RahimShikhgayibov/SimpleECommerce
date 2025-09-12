using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleECommerce.Domain.Entities;

namespace SimpleECommerce.Infrastructure.Configurations;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("addresses");

        builder.HasKey(a => a.Id)
            .HasName("pk_addresses");
        
        builder.Property(e => e.Id)
            .IsRequired()
            .HasColumnName("id");
        
        builder.Property(a => a.AddressLine1)
            .IsRequired()
            .HasColumnName("address_line1");
        
        builder.Property(a => a.AddressLine2)
            .IsRequired()
            .HasColumnName("address_line2");
        
        builder.Property(a => a.Street)
            .IsRequired()
            .HasColumnName("street");
        
        builder.Property(a => a.City)
            .IsRequired()
            .HasColumnName("city");
        
        builder.Property(a => a.State)
            .IsRequired()
            .HasColumnName("state");
        
        builder.Property(a => a.PostalCode)
            .IsRequired()
            .HasColumnName("postal_code");
        
        builder.Property(a => a.Country)
            .IsRequired()
            .HasColumnName("country");
        
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