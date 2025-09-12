using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleECommerce.Domain.Entities;

namespace SimpleECommerce.Infrastructure.Configurations;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("addresses");

        builder.HasKey(a => a.Id).HasName("pk_addresses");

        builder.Property(a => a.Id).HasColumnName("id").IsRequired();

        // Example properties (adjust names to your model)
        builder.Property(a => a.Street).HasColumnName("street");
        builder.Property(a => a.City).HasColumnName("city");
        builder.Property(a => a.State).HasColumnName("state");
        builder.Property(a => a.PostalCode).HasColumnName("postal_code");
        builder.Property(a => a.Country).HasColumnName("country");
    }
}