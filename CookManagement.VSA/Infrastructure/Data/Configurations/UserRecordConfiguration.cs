using CookManagement.VSA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CookManagement.VSA.Infrastructure.Data.Configurations;

public class UserRecordConfiguration : IEntityTypeConfiguration<UserRecord>
{
    public void Configure(EntityTypeBuilder<UserRecord> builder)
    {
        builder.HasKey(r => r.Id);

        builder.HasOne(r => r.User).WithMany(u => u.UserRecords)
            .HasForeignKey(r => r.UserId).OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(r => new { r.UserId, r.ProductCode, r.CreatedAt })
            .HasDatabaseName("IX_UserRecords_UserId_ProductCode_CreatedAt");

        builder.Property(p => p.ProductCode)
            .HasMaxLength(10).IsRequired();

        builder.Property(b => b.ProductName)
            .HasMaxLength(100).IsRequired();

        builder.Property(p => p.InitialInventory)
            .HasDefaultValue(0);

        builder.Property(p => p.FinalInventory)
            .HasDefaultValue(0);

        builder.Property(p => p.Difference)
            .HasDefaultValue(0);

        builder.Property(p => p.DailyMove)
            .HasDefaultValue(0);

        builder.Property(p => p.Entries)
            .HasDefaultValue(0);

        builder.Property(p => p.Courtesy)
            .HasDefaultValue(0);

        builder.Property(p => p.Damaged)
            .HasDefaultValue(0);

        builder.Property(p => p.Remains)
            .HasDefaultValue(0);

        builder.Property(p => p.InventoryType)
            .HasConversion<string>();

        builder.Property(p => p.CreatedAt)
            .HasDefaultValue(DateTimeOffset.Now);

        builder.Property(p => p.UpdatedAt)
            .HasDefaultValue(DateTimeOffset.Now);
    }
}
