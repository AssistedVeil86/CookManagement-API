using CookManagement.VSA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CookManagement.VSA.Infrastructure.Data.Configurations;

public class BarInventoryConfiguration : IEntityTypeConfiguration<BarInventory>
{
    public void Configure(EntityTypeBuilder<BarInventory> builder)
    {
        builder.HasKey(b => b.Code);

        builder.Property(b => b.Code)
            .HasMaxLength(10);

        builder.Property(b => b.Product)
            .HasMaxLength(100).IsRequired();

        builder.Property(b => b.Category)
            .HasMaxLength(50);

        builder.Property(b => b.MinimumStock)
            .HasDefaultValue(0);

        builder.Property(b => b.CurrentStock)
            .HasDefaultValue(0.0);
    }
}
