using managerBackend.Models;
using managerBackend.Constants;

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
            modelBuilder.Entity<User>().HasData(admins);
            modelBuilder.Entity<User>()
                .HasMany(p => p.Roles)
                .WithMany(p => p.Users)
                .UsingEntity(j => j.HasData(new { UsersId = 1, RolesId = 1 }));
        }

        private static void InitDistances(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Distance>().HasData(
                        new Distance(1, DistanceConstants.FL50),
                        new Distance(2, DistanceConstants.BK50),
                        new Distance(3, DistanceConstants.BR50),
                        new Distance(4, DistanceConstants.FR50),

                        new Distance(5, DistanceConstants.FL100),
                        new Distance(6, DistanceConstants.BK100),
                        new Distance(7, DistanceConstants.BR100),
                        new Distance(8, DistanceConstants.FR100),
                        new Distance(9, DistanceConstants.IM100),

                        new Distance(10, DistanceConstants.FL200),
                        new Distance(11, DistanceConstants.BK200),
                        new Distance(12, DistanceConstants.BR200),
                        new Distance(13, DistanceConstants.FR200),
                        new Distance(14, DistanceConstants.IM200),

                        new Distance(15, DistanceConstants.FR400),
                        new Distance(16, DistanceConstants.IM400),

                        new Distance(17, DistanceConstants.FR800),
                        new Distance(18, DistanceConstants.FR1500),

                        new Distance(19, DistanceConstants.RLFR100),
                        new Distance(20, DistanceConstants.RLIM100),
                        new Distance(21, DistanceConstants.RLFR200));
        }
    }
}
