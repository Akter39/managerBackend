using managerBackend.Models;

using Microsoft.EntityFrameworkCore;

namespace managerBackend
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBudilder)
        {
            Role mainAdmin = new Role { Id = 1, Name = "MainAdmin" };
            Role admin = new Role { Id = 2, Name = "Admin" };
            Role user = new Role { Id = 3, Name = "User" };
            Role vipUser = new Role { Id = 4, Name = "VipUser" };

            User mainUser = new User
            {
                Id = 1,
                UserNickname = "MainAdmin",
                UserEmail = "akt@mm.com",
                UserName = "mainadmin",
                UserOrganization = "Administrations",
                UserPhone = "89111111111",
                UserCity = "Moscow",
                UserPassword = "mainadmin"
            };
            modelBudilder.Entity<Role>().HasData(mainAdmin, admin, user, vipUser);
            modelBudilder.Entity<User>().HasData(mainUser);
            modelBudilder.Entity<User>()
                .HasMany(p => p.Roles)
                .WithMany(p => p.Users)
                .UsingEntity(j => j.HasData(new { UsersId = 1, RolesId = 1 }));
        }
    }
}
