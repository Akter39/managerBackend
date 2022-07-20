using managerBackend.Models;
using managerBackend.ViewModels;

using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

using System.Data;
using System.IdentityModel.Tokens.Jwt;

using System.Security.Claims;
using System.Security.Cryptography;

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

        public ConditionSignIn SignIn(ConditionSignIn condition, User? sentUser, string ip)
        {
            condition.CurrentUser = GenerateCurrentUser(sentUser);
            condition.CurrentUser!.Token = GenerateJwt(sentUser);
            return condition;
        }

        private static CurrentUser GenerateCurrentUser(User? sentUser)
        {
            List<string> roles = new();
            foreach (var role in sentUser!.Roles)
            {
                roles.Add(role.Name);
            }
            return new CurrentUser()
            {
                Id = sentUser!.Id,
                Nickname = sentUser.UserNickname,
                Organization = sentUser.UserOrganization,
                City = sentUser.UserCity,
                Roles = roles
            };
        }

        private static String GenerateJwt(User? sentUser)
        {
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
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(10)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        private RefreshToken GenerateRefreshJwt(string ip)
        {
            using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                var randomBytes = new byte[64];
                rngCryptoServiceProvider.GetBytes(randomBytes);
                return new RefreshToken
                {
                    Token = Convert.ToBase64String(randomBytes),
                    Expires = DateTime.UtcNow.AddDays(365),
                    Created = DateTime.UtcNow,
                    CreatedByIp = ip
                };
            }
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
