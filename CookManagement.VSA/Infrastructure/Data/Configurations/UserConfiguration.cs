using CookManagement.VSA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CookManagement.VSA.Infrastructure.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Name)
            .HasMaxLength(100).IsRequired();

        builder.Property(u => u.Password)
            .HasMaxLength(100).IsRequired();

        builder.Property(u => u.Role)
            .HasConversion<string>();
    }
}
