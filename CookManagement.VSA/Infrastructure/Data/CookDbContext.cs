using CookManagement.VSA.Domain.Entities;
using CookManagement.VSA.Domain.Enums;
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

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CookDbContext).Assembly);

            //Seed Data
            SeedAdmins(modelBuilder);
            SeedBarUsers(modelBuilder);
            SeedKitchenUsers(modelBuilder);
            SeedSuperAdmin(modelBuilder);
        }

        private void SeedAdmins(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Vcastro",
                    Password = BCrypt.Net.BCrypt.HashPassword("GenericPassword"),
                    Role = UserRole.Admin
                },
                new User
                {
                    Id = 2,
                    Name = "Gcastillo",
                    Password = BCrypt.Net.BCrypt.HashPassword("GenericPassword"),
                    Role = UserRole.Admin
                },
                new User
                {
                    Id = 3,
                    Name = "Pcasco",
                    Password = BCrypt.Net.BCrypt.HashPassword("GenericPassword"),
                    Role = UserRole.Admin
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
                    Password = BCrypt.Net.BCrypt.HashPassword("GenericPassword"),
                    Role = UserRole.Cocina
                },
                new User
                {
                    Id = 5,
                    Name = "Marifonseca",
                    Password = BCrypt.Net.BCrypt.HashPassword("GenericPassword"),
                    Role = UserRole.Cocina
                },
                new User
                {
                    Id = 6,
                    Name = "Astridvalle",
                    Password = BCrypt.Net.BCrypt.HashPassword("GenericPassword"),
                    Role = UserRole.Cocina
                },
                new User
                {
                    Id = 9,
                    Name = "Jcastillo",
                    Password = BCrypt.Net.BCrypt.HashPassword("GenericPassword"),
                    Role = UserRole.Cocina
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
                    Password = BCrypt.Net.BCrypt.HashPassword("GenericPassword"),
                    Role = UserRole.Bar
                },
                new User
                {
                    Id = 8,
                    Name = "Elinuñez",
                    Password = BCrypt.Net.BCrypt.HashPassword("GenericPassword"),
                    Role = UserRole.Bar
                },

                new User
                {
                    Id = 10,
                    Name = "Lorebustillo",
                    Password = BCrypt.Net.BCrypt.HashPassword("GenericPassword"),
                    Role = UserRole.Bar
                },
                new User
                {
                    Id = 11,
                    Name = "Elisanchez",
                    Password = BCrypt.Net.BCrypt.HashPassword("GenericPassword"),
                    Role = UserRole.Bar
                }
            );
        }

        private void SeedSuperAdmin(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 12,
                    Name = "AdminLinus",
                    Password = BCrypt.Net.BCrypt.HashPassword("GenericPassword"),
                    Role = UserRole.SuperAdmin
                }
            );
        }
    }
}
