using managerBackend.Models;
using managerBackend.Constants;
using managerBackend.Helpers;

using Microsoft.EntityFrameworkCore;

namespace managerBackend
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<Distance> Distances { get; set; } = null!;
        public DbSet<Competition> Competitions { get; set; } = null!;
        public DbSet<RefreshToken> RefreshTokens { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            InitDate(modelBuilder);

            modelBuilder.Entity<User>().Property(u => u.Id).ValueGeneratedOnAdd().UseIdentityColumn(1000,1);
            
        }

        private static void InitDate(ModelBuilder modelBuilder)
        {
            InitRoles(modelBuilder);
            InitAdmins(modelBuilder);
            InitDistances(modelBuilder);
        }

        private static void InitRoles(ModelBuilder modelBuilder)
        {
            List<Role> roles = new List<Role>();
            roles.Add(new Role { Id = 1, Name = "MainAdmin" });
            roles.Add(new Role { Id = 2, Name = "Admin" });
            roles.Add(new Role { Id = 3, Name = "User" });
            roles.Add(new Role { Id = 4, Name = "VipUser" });
            modelBuilder.Entity<Role>().HasData(roles);

        }
        
        private static void InitAdmins(ModelBuilder modelBuilder)
        {
            List<User> admins = new();
            admins.Add(new User
            {
                Id = 1,
                UserNickname = "MainAdmin",
                UserEmail = "akt@mm.com",
                UserName = "mainadmin",
                UserOrganization = "Administrations",
                UserPhone = "89111111111",
                UserCity = "Moscow",
                UserPassword = "mainadmin"
            });
            admins.Add(new User
            {
                Id = 1000,
                UserNickname = "Admin1000",
                UserEmail = "foo@foo.com",
                UserName = "Admin1000",
                UserOrganization = "Administrations",
                UserPhone = "89111111145",
                UserCity = "Moscow",
                UserPassword = "admin1000"
            });
            modelBuilder.Entity<User>().HasData(admins);
            modelBuilder.Entity<User>()
                .HasMany(p => p.Roles)
                .WithMany(p => p.Users)
                .UsingEntity(j => j.HasData(new { UsersId = 1, RolesId = 1 }, new {UsersId = 1000, RolesId = 2}));
        }

        private static void InitDistances(ModelBuilder modelBuilder)
        {
            List<Distance> distances = new();
            List<string> distancesConst = typeof(DistanceConstants).GetPublicContants<string>();
            int i = 0;
            foreach (var item in distancesConst)
            {
                distances.Add(new Distance(++i, item, "Male"));
            }
            foreach (var item in distancesConst)
            {
                distances.Add(new Distance(++i, item, "Female"));
            }
            modelBuilder.Entity<Distance>().HasData(distances);
        }
    }
}
