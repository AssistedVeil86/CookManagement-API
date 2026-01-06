using CookManagement.VSA.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace CookManagement.VSA.Infrastructure.Data
{
    public class CookDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserRecord> UserRecords { get; set; }
        public DbSet<BarInventory> BarInventory { get; set; }
        public DbSet<KitchenInventory> KitchenInventory { get; set; }
        public CookDbContext(DbContextOptions<CookDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Primary Keys
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<UserRecord>().HasKey(r => r.Id);
            modelBuilder.Entity<BarInventory>().HasKey(b => b.Code);
            modelBuilder.Entity<KitchenInventory>().HasKey(k => k.Code);

            //Foreign Keys
            modelBuilder.Entity<UserRecord>().HasOne(r => r.User).WithMany(u => u.UserRecords)
                .HasForeignKey(r => r.UserId).OnDelete(DeleteBehavior.Cascade);

            //Indexes
            modelBuilder.Entity<UserRecord>()
                .HasIndex(r => new { r.UserId, r.ProductCode, r.CreatedAt })
                .HasDatabaseName("IX_UserRecords_UserId_ProductCode_CreatedAt");

            //Configuring Entities
            ConfigureUserEntity(modelBuilder);
            ConfigureUserRecordsEntity(modelBuilder);
            ConfigureInventoryEntities(modelBuilder);

            //Seed Data
            SeedAdmins(modelBuilder);
            SeedBarUsers(modelBuilder);
            SeedKitchenUsers(modelBuilder);
            SeedSuperAdmin(modelBuilder);
        }

        private void ConfigureUserEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(u => u.Name)
                .HasMaxLength(100).IsRequired();

                entity.Property(u => u.Password)
                    .HasMaxLength(100).IsRequired();

                entity.Property(u => u.Role)
                .HasConversion<String>();
            });
        }

        private void ConfigureUserRecordsEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRecord>(entity =>
            {
                entity.Property(p => p.ProductCode)
                    .HasMaxLength(10).IsRequired();

                entity.Property(b => b.ProductName)
                    .HasMaxLength(100).IsRequired();

                entity.Property(p => p.InitialInventory)
                    .HasDefaultValue(0);

                entity.Property(p => p.FinalInventory)
                    .HasDefaultValue(0);

                entity.Property(p => p.Difference)
                    .HasDefaultValue(0);

                entity.Property(p => p.DailyMove)
                    .HasDefaultValue(0);

                entity.Property(p => p.Entries)
                    .HasDefaultValue(0);

                entity.Property(p => p.Courtesy)
                    .HasDefaultValue(0);

                entity.Property(p => p.Damaged)
                    .HasDefaultValue(0);

                entity.Property(p => p.Remains)
                    .HasDefaultValue(0);

                entity.Property(p => p.InventoryType)
                    .HasConversion<String>();

                entity.Property(p => p.CreatedAt)
                    .HasDefaultValue(DateTimeOffset.Now);

                entity.Property(p => p.UpdatedAt)
                    .HasDefaultValue(DateTimeOffset.Now);
            });
        }

        private void ConfigureInventoryEntities(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BarInventory>(entity =>
            {
                entity.Property(b => b.Code)
                    .HasMaxLength(10);

                entity.Property(b => b.Product)
                    .HasMaxLength(100).IsRequired();

                entity.Property(b => b.Category)
                    .HasMaxLength(50);

                entity.Property(b => b.MinimumStock)
                    .HasDefaultValue(0);

                entity.Property(b => b.CurrentStock)
                    .HasDefaultValue(0.0);
            });

            modelBuilder.Entity<KitchenInventory>(entity =>
            {
                entity.Property(k => k.Code)
                    .HasMaxLength(10);

                entity.Property(k => k.Product)
                    .HasMaxLength(100).IsRequired();

                entity.Property(k => k.Category)
                    .HasMaxLength(50);

                entity.Property(k => k.MeasurementUnit)
                    .HasMaxLength(50);

                entity.Property(k => k.MinimumStock)
                    .HasDefaultValue(0.0);

                entity.Property(k => k.CurrentStock)
                    .HasDefaultValue(0.0);
            });
        }

        private void SeedAdmins(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Vcastro",
                    Password = BCrypt.Net.BCrypt.HashPassword("GenericPassword123!"),
                    Role = Shared.Enums.UserRole.Admin
                },
                new User
                {
                    Id = 2,
                    Name = "Gcastillo",
                    Password = BCrypt.Net.BCrypt.HashPassword("GenericPassword123!"),
                    Role = Shared.Enums.UserRole.Admin
                },
                new User
                {
                    Id = 3,
                    Name = "Pcasco",
                    Password = BCrypt.Net.BCrypt.HashPassword("GenericPassword123!"),
                    Role = Shared.Enums.UserRole.Admin
                }
            );
        }

        private void SeedKitchenUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 4,
                    Name = "Alevaldez",
                    Password = BCrypt.Net.BCrypt.HashPassword("GenericPassword123!"),
                    Role = Shared.Enums.UserRole.Cocina
                },
                new User
                {
                    Id = 5,
                    Name = "Marifonseca",
                    Password = BCrypt.Net.BCrypt.HashPassword("GenericPassword123!"),
                    Role = Shared.Enums.UserRole.Cocina
                },
                new User
                {
                    Id = 6,
                    Name = "Astridvalle",
                    Password = BCrypt.Net.BCrypt.HashPassword("GenericPassword123!"),
                    Role = Shared.Enums.UserRole.Cocina
                },
                new User
                {
                    Id = 9,
                    Name = "Jcastillo",
                    Password = BCrypt.Net.BCrypt.HashPassword("GenericPassword123!"),
                    Role = Shared.Enums.UserRole.Cocina
                }
            );
        }

        private void SeedBarUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 7,
                    Name = "SherMurillo",
                    Password = BCrypt.Net.BCrypt.HashPassword("GenericPassword123!"),
                    Role = Shared.Enums.UserRole.Bar
                },
                new User
                {
                    Id = 8,
                    Name = "Elinuñez",
                    Password = BCrypt.Net.BCrypt.HashPassword("GenericPassword123!"),
                    Role = Shared.Enums.UserRole.Bar
                },

                new User
                {
                    Id = 10,
                    Name = "Gperez",
                    Password = BCrypt.Net.BCrypt.HashPassword("GenericPassword123!"),
                    Role = Shared.Enums.UserRole.Bar
                }
            );
        }

        private void SeedSuperAdmin(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 11,
                    Name = "AdminLinus",
                    Password = BCrypt.Net.BCrypt.HashPassword("GenericPassword123!"),
                    Role = Shared.Enums.UserRole.SuperAdmin
                }
            );
        }
    }
}
