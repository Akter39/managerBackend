using managerBackend.Constants;
using managerBackend.Models;
using managerBackend.ViewModels;

using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

using System.IdentityModel.Tokens.Jwt;

using System.Security.Claims;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
namespace managerBackend.Services
{
    public class UserService: IUserService<CurrentUser>
    {
        ApplicationContext db;
        IHttpContextAccessor httpContextAccessor;
        public UserService(ApplicationContext context, IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
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

        public async Task<CurrentUser> SignIn(CurrentUser responce, User? sentUser, string ip)
        {
            responce = GenerateCurrentUser(sentUser);
            responce!.Token = GenerateJwt(sentUser);
            RefreshToken refreshToken = GenerateRefreshJwt(ip);
            responce.RefreshJwt = refreshToken.Token;
            sentUser!.RefreshTokens.Add(refreshToken);  
            db.Update(sentUser);
            await db.SaveChangesAsync();
            return responce;
        } 

        public async Task<CurrentUser> RefreshJwt(string jwt, string ip)
        {
            var user = await db.Users
                .Include(u => u.RefreshTokens)
                .Include(u => u.Roles)
                .AsSplitQuery()
                .FirstOrDefaultAsync(u => u.RefreshTokens.Any(u => u.Token == jwt));
            if (user == null) return null;

            var refreshJwt = user.RefreshTokens.FirstOrDefault(u => u.Token == jwt);

            if (!refreshJwt!.IsActive) return null;

            var newRefreshJwt = GenerateRefreshJwt(ip);
            refreshJwt.Revoked = DateTime.UtcNow;
            refreshJwt.RevokedByIp = ip;
            refreshJwt.ReplacedByToken = newRefreshJwt.Token;
            user.RefreshTokens.Add(newRefreshJwt);
            db.Update(user);
            await db.SaveChangesAsync();

            var currentUser = GenerateCurrentUser(user);
            currentUser.Token = GenerateJwt(user);
            currentUser.RefreshJwt = newRefreshJwt.Token;

            return currentUser;
        }

        public async Task<Boolean> RevokeJwt(string jwt, string ip)
        {
            var user = await db.Users.Include(u => u.RefreshTokens).FirstOrDefaultAsync(u => u.RefreshTokens.Any(u => u.Token == jwt));
            if (user == null) return false;

            var refreshJwt = user.RefreshTokens.FirstOrDefault(u => u.Token == jwt);

            if (!refreshJwt!.IsActive) return false;

            refreshJwt.Revoked = DateTime.UtcNow;
            refreshJwt.RevokedByIp = ip;

            db.Update(user);
            await db.SaveChangesAsync();

            return true;
        }

        public string IpAddress()
        {
            if (httpContextAccessor.HttpContext!.Request.Headers.ContainsKey("X-Forwarded-For"))
                return httpContextAccessor.HttpContext!.Request.Headers["X-Forwarded-For"];
            else
                return httpContextAccessor.HttpContext!.Connection.RemoteIpAddress!.MapToIPv4().ToString();
        }

        public void setTokenCookie(string token)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(7)
            };
            httpContextAccessor.HttpContext!.Response.Cookies.Append("RefreshToken", token, cookieOptions);
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

            claims.Add(new Claim("id", sentUser!.Id.ToString()));
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
                    Expires = DateTime.UtcNow.AddDays(7),
                    Created = DateTime.UtcNow,
                    CreatedByIp = ip
                };
            }
        }

    }

    public static class UserManagerExtensions
    {
        public static void AddUserManager<TService, TImplementation>(this IServiceCollection services)
            where TService : class
            where TImplementation : class, IUserService<TService>
        {
            services.AddScoped<IUserService<TService>, TImplementation>();
        }
    }
}
