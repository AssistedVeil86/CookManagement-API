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
                    Password = "$2a$11$REAfSznGeEc/Znk77Htx7OX33HEulgxqicDF4Szd2yVUAC0HmQeZC",
                    Role = UserRole.Admin
                },
                new User
                {
                    Id = 2,
                    Name = "Gcastillo",
                    Password = "$2a$11$Fuh8LvVLwEw3ertU3ZS0pO0Hl1vEQr7fM5OWCT4JhdQOgMeuWMnnS",
                    Role = UserRole.Admin
                },
                new User
                {
                    Id = 3,
                    Name = "Pcasco",
                    Password = "$2a$11$w7UpmeGBC8B2V7eWXYH93e7ptsEZibk8rvnoBXwXE6FP9UR/KxPNa",
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
                    Password = "$2a$11$OvurlxftIiFNcq4c3kDNnu6qJ5QQ4YCv149qcemIj65MSJzIuicZy",
                    Role = UserRole.Cocina
                },
                new User
                {
                    Id = 5,
                    Name = "Marifonseca",
                    Password = "$2a$11$4cINv0.do.dmaZYgHw27AOdAmvlluglpL.aK.s9HpOXvriZ1tGyti",
                    Role = UserRole.Cocina
                },
                new User
                {
                    Id = 6,
                    Name = "Astridvalle",
                    Password = "$2a$11$aYFBaZkJFjJG3kJO2VBpzezRzQkRn.IK2M2bSxNTokpi2hA6YXe/u",
                    Role = UserRole.Cocina
                },
                new User
                {
                    Id = 9,
                    Name = "Jcastillo",
                    Password = "$2a$11$G3uQiwH.j9UdyiQGoHeghOttoYu0xW9W2SeBhQ8wtX9q4he4.MkcG",
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
                    Password = "$2a$11$nk/GVbJLCjUsNuQlv7cK5u9enEN.HhfFuEbxXC2sexeu0RzagMPqG",
                    Role = UserRole.Bar
                },
                new User
                {
                    Id = 8,
                    Name = "Elinuñez",
                    Password = "$2a$11$rcVIjn1iZ/aWIDJjJ35truMlSFN/6waR5F6.G9f3H0ck7usmwecZa",
                    Role = UserRole.Bar
                },

                new User
                {
                    Id = 10,
                    Name = "Lorebustillo",
                    Password = "$2a$11$loKK6dbPBuWGmai4HOfx6.nUMOLqIzD5XpnTy0VQEPBNE1OHoPaSm",
                    Role = UserRole.Bar
                },
                new User
                {
                    Id = 11,
                    Name = "Elisanchez",
                    Password = "$2a$11$woU1KtL6iAv07y894MMpOuEqSnf4TRk6m.pX/xljv8cZgc2/5xkXS",
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
                    Password = "$2a$11$S/80J1F/Tsfau6nkXBPaYufOqU59dnnnc2M12IHTPT17uKjevkyEi",
                    Role = UserRole.SuperAdmin
                }
            );
        }
    }
}
