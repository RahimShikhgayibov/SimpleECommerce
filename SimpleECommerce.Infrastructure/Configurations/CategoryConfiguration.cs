using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleECommerce.Domain.Entities;

namespace SimpleECommerce.Infrastructure.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("categories");

        builder.HasKey(c => c.Id).HasName("pk_categories");
        builder.Property(c => c.Id).HasColumnName("id").IsRequired();
        builder.Property(c => c.Name).HasColumnName("name").IsRequired();
        builder.Property(c => c.Description).HasColumnName("description");
        builder.Property(c => c.IsActive).HasColumnName("is_active").HasDefaultValue(true);

        builder.HasData(
            new Category { Id = 1, Name = "Electronics", Description = "Electronic devices and accessories", IsActive = true },
            new Category { Id = 2, Name = "Books", Description = "Books and magazines", IsActive = true }
        );
    }
}