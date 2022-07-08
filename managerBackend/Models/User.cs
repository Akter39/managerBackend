using managerBackend.ViewModels;

using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace managerBackend.Models
{
    public class User
    {
        [BindNever]
        public int Id { get; set; }
        public string UserNickname { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        [NotMapped]
        public string UserConfirmPassword { get; set; }
        public string UserEmail { get; set; }
        public string UserPhone { get; set; }
        public string UserCity { get; set; }
        public string UserOrganization { get; set; }
        [BindNever]
        public List<Role> Roles { get; set; } = new();
        [BindNever]
        public List<Competition> Competitions { get; set; } = new();
        public static async Task<ConditionSignUp> VerificationUser(ApplicationContext db, User user)
        {
            ConditionSignUp condition = new ConditionSignUp();
            if (!Regex.IsMatch(user.UserName, RegexConstants.userName))
            {
                condition.InvalidNameFormat = true;
                condition.Successful = false;
            } 
            else
                if (await db.Users.AnyAsync(u => u.UserName == user.UserName))
            {
                condition.NameBusy = true;
                condition.Successful = false;
            }

            if (!Regex.IsMatch(user.UserNickname, RegexConstants.userName))
            {
                condition.InvalidNicknameFormat = true;
                condition.Successful = false;
            }
            else
                if (await db.Users.AnyAsync(u => u.UserNickname == user.UserNickname))
            {
                condition.NicknameBusy = true;
                condition.Successful = false;
            }

            if (!Regex.IsMatch(user.UserPhone, RegexConstants.userPhone))
            {
                condition.InvalidPhoneFormat = true;
                condition.Successful = false;
            }
            else
                if (await db.Users.AnyAsync(u => u.UserPhone == user.UserPhone))
            {
                condition.PhoneBusy = true;
                condition.Successful = false;
            }

            if (!Regex.IsMatch(user.UserEmail, RegexConstants.userEmail, RegexOptions.IgnoreCase))
            {
                condition.InvalidEmailFormat = true;
                condition.Successful = false;
            }
            else
                if (await db.Users.AnyAsync(u => u.UserEmail == user.UserEmail))
            {
                condition.EmailBusy = true;
                condition.Successful = false;
            }

            if (!Regex.IsMatch(user.UserPassword, RegexConstants.userPassword) || !Regex.IsMatch(user.UserConfirmPassword, RegexConstants.userPassword))
            {
                condition.InvalidPasswordFormat = true;
                condition.Successful = false;
            }
            if (user.UserPassword != user.UserConfirmPassword)
            {
                condition.NotMatchPasswords = true;
                condition.Successful = false;
            }

            if (!Regex.IsMatch(user.UserCity, RegexConstants.userCity))
            {
                condition.InvalidCityFormat = true;
                condition.Successful = false;
            }
            if (!Regex.IsMatch(user.UserOrganization, RegexConstants.userOrganization))
            {
                condition.InvalidOrganizationFormat = true;
                condition.Successful = false;
            }
            return condition;
        }
    }
}
