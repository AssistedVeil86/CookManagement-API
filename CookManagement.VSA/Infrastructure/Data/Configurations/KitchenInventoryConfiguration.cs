using CookManagement.VSA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CookManagement.VSA.Infrastructure.Data.Configurations;

public class KitchenInventoryConfiguration : IEntityTypeConfiguration<KitchenInventory>
{
    public void Configure(EntityTypeBuilder<KitchenInventory> builder)
    {
        builder.HasKey(k => k.Code);

        builder.Property(k => k.Code)
            .HasMaxLength(10);

        builder.Property(k => k.Product)
            .HasMaxLength(100).IsRequired();

        builder.Property(k => k.Category)
            .HasMaxLength(50);

        builder.Property(k => k.MeasurementUnit)
            .HasMaxLength(50);

        builder.Property(k => k.MinimumStock)
            .HasDefaultValue(0.0);

        builder.Property(k => k.CurrentStock)
            .HasDefaultValue(0.0);
    }
}
