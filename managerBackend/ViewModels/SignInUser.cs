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
        public static async Task<(ConditionSignIn, User?)> VerificationSignIn(ApplicationContext db, SignInUser user, ConditionSignIn condition)
        {
            User? sentUser = null;

            if (Regex.IsMatch(user.UserLogin, RegexConstants.userPhone)) sentUser = await db.Users.Include(u => u.Roles).FirstOrDefaultAsync(u =>
                u.UserPhone == user.UserLogin && u.UserPassword == user.UserPassword);
            else
                if (Regex.IsMatch(user.UserLogin, RegexConstants.userEmail)) sentUser = await db.Users.Include(u => u.Roles).FirstOrDefaultAsync(u =>
                    u.UserEmail == user.UserLogin && u.UserPassword == user.UserPassword);
            else
                if (Regex.IsMatch(user.UserLogin, RegexConstants.userName)) sentUser = await db.Users.Include(u => u.Roles).FirstOrDefaultAsync(u =>
                    u.UserName == user.UserLogin && u.UserPassword == user.UserPassword);
            else
            {
                condition.Successful = false;
                condition.InvalidLoginFormat = true;
            }

            if (sentUser == null)
            {
                condition.Successful = false;
                condition.InvalidSignIn = true;
            }

            return (condition, sentUser);
        }
    }
}
