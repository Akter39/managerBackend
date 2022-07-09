using managerBackend.Constants;
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
        [MaxLength(14)]
        public string UserNickname { get; set; }
        [MaxLength(14)]
        public string UserName { get; set; }
        [MaxLength(20)]
        public string UserPassword { get; set; }
        [NotMapped]
        public string UserConfirmPassword { get; set; }
        [MaxLength(64)]
        public string UserEmail { get; set; }
        [MaxLength(20)]
        public string UserPhone { get; set; }
        [MaxLength(20)]
        public string UserCity { get; set; }
        [MaxLength(30)]
        public string UserOrganization { get; set; }
        [BindNever]
        public List<Role> Roles { get; set; } = new();
        [BindNever]
        public List<Competition> Competitions { get; set; } = new List<Competition>();
        public static async Task<ConditionSignUp> VerificationUser(ApplicationContext db, User user)
        {
            ConditionSignUp condition = new ConditionSignUp();
            if (!Regex.IsMatch(user.UserName, RegexConsts.userName))
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

            if (!Regex.IsMatch(user.UserNickname, RegexConsts.userName))
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

            if (!Regex.IsMatch(user.UserPhone, RegexConsts.userPhone))
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

            if (!Regex.IsMatch(user.UserEmail, RegexConsts.userEmail, RegexOptions.IgnoreCase))
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

            if (!Regex.IsMatch(user.UserPassword, RegexConsts.userPassword) || !Regex.IsMatch(user.UserConfirmPassword, RegexConsts.userPassword))
            {
                condition.InvalidPasswordFormat = true;
                condition.Successful = false;
            }
            if (user.UserPassword != user.UserConfirmPassword)
            {
                condition.NotMatchPasswords = true;
                condition.Successful = false;
            }

            if (!Regex.IsMatch(user.UserCity, RegexConsts.userCity))
            {
                condition.InvalidCityFormat = true;
                condition.Successful = false;
            }
            if (!Regex.IsMatch(user.UserOrganization, RegexConsts.userOrganization))
            {
                condition.InvalidOrganizationFormat = true;
                condition.Successful = false;
            }
            return condition;
        }
    }
}
