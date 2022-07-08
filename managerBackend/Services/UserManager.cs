using managerBackend.Models;
using managerBackend.ViewModels;

using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

using System.IdentityModel.Tokens.Jwt;

using System.Security.Claims;

namespace managerBackend.Services
{
    public class UserManager
    {
        ApplicationContext db;
        public UserManager(ApplicationContext context)
        {
            db = context;
        }

        public async Task<bool> NewUser(User user, string defaultRole)
        {
            if (!String.IsNullOrEmpty(defaultRole))
            {
                Role? roleUser = await db.Roles.FirstOrDefaultAsync(c => c.Name == defaultRole);
                if (roleUser != null)
                {
                    user.Roles.Add(roleUser);
                    db.Users.Add(user);
                    await db.SaveChangesAsync();
                    return true;
                } 
            }
            return false;
        }

        public async Task<ConditionSignIn> SignIn(ConditionSignIn condition, User? sentUser)
        {
            List<string> roles = new List<string>();
            foreach (var role in sentUser.Roles)
            {
                roles.Add(role.Name);
            }
            condition.CurrentUser = new CurrentUser()
            {
                Id = sentUser!.Id,
                Nickname = sentUser.UserNickname,
                Organization = sentUser.UserOrganization,
                City = sentUser.UserCity,
                Roles = roles
            };

            var claims = new List<Claim>();

            claims.Add(new Claim("username", sentUser!.UserName));
            claims.Add(new Claim("nickname", sentUser!.UserNickname));

            foreach (var role in sentUser!.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Name));
            }

            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            condition.CurrentUser!.Token = new JwtSecurityTokenHandler().WriteToken(jwt);
            return condition;
        }
    }

    public static class UserManagerExtensions
    {
        public static void AddUserManager(this IServiceCollection service)
        {
            service.AddTransient<UserManager>();
        }
    }
}
