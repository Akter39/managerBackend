using managerBackend.Constants;
using managerBackend.Models;

using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

using System.Text.RegularExpressions;

namespace managerBackend.ViewModels
{
    public class SignInUser
    {
        public string UserLogin{ get; set; }
        public string UserPassword { get; set; }
        public static async Task<(ConditionSignIn, User?)> VerificationSignIn(ApplicationContext db, SignInUser user, ConditionSignIn responce)
        {
            User? sentUser = new();

            if (Regex.IsMatch(user.UserLogin, UserConsts.userPhone)) sentUser = await db.Users.Include(u => u.Roles).FirstOrDefaultAsync(u =>
                u.UserPhone == user.UserLogin && u.UserPassword == user.UserPassword);
            else
                if (Regex.IsMatch(user.UserLogin, UserConsts.userEmail)) sentUser = await db.Users.Include(u => u.Roles)/*.Include(u => u.RefreshTokens)*/.FirstOrDefaultAsync(u =>
                    u.UserEmail == user.UserLogin && u.UserPassword == user.UserPassword);
            else
                if (Regex.IsMatch(user.UserLogin, UserConsts.userName)) sentUser = await db.Users.Include(u => u.Roles).FirstOrDefaultAsync(u =>
                    u.UserName == user.UserLogin && u.UserPassword == user.UserPassword);
            else
            {
                responce.Successful = false;
                responce.InvalidLoginFormat = true;
            }

            if (sentUser == null)
            {
                responce.Successful = false;
                responce.InvalidSignIn = true;
            }

            return (responce, sentUser);
        }
    }
}
