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
        public List<RefreshToken> RefreshTokens { get; set; } = new();
        [BindNever]
        public List<Competition> Competitions { get; set; } = new List<Competition>();
        public static async Task<ConditionSignUp> VerificationUser(ApplicationContext db, User user)
        {
            ConditionSignUp responce = new ConditionSignUp();
            if (!Regex.IsMatch(user.UserName, UserConsts.userName))
            {
                responce.InvalidNameFormat = true;
                responce.Successful = false;
            } 
            else
                if (await db.Users.AnyAsync(u => u.UserName == user.UserName))
            {
                responce.NameBusy = true;
                responce.Successful = false;
            }

            if (!Regex.IsMatch(user.UserNickname, UserConsts.userName))
            {
                responce.InvalidNicknameFormat = true;
                responce.Successful = false;
            }
            else
                if (await db.Users.AnyAsync(u => u.UserNickname == user.UserNickname))
            {
                responce.NicknameBusy = true;
                responce.Successful = false;
            }

            if (!Regex.IsMatch(user.UserPhone, UserConsts.userPhone))
            {
                responce.InvalidPhoneFormat = true;
                responce.Successful = false;
            }
            else
                if (await db.Users.AnyAsync(u => u.UserPhone == user.UserPhone))
            {
                responce.PhoneBusy = true;
                responce.Successful = false;
            }

            if (!Regex.IsMatch(user.UserEmail, UserConsts.userEmail, RegexOptions.IgnoreCase))
            {
                responce.InvalidEmailFormat = true;
                responce.Successful = false;
            }
            else
                if (await db.Users.AnyAsync(u => u.UserEmail == user.UserEmail))
            {
                responce.EmailBusy = true;
                responce.Successful = false;
            }

            if (!Regex.IsMatch(user.UserPassword, UserConsts.userPassword) || !Regex.IsMatch(user.UserConfirmPassword, UserConsts.userPassword))
            {
                responce.InvalidPasswordFormat = true;
                responce.Successful = false;
            }
            if (user.UserPassword != user.UserConfirmPassword)
            {
                responce.NotMatchPasswords = true;
                responce.Successful = false;
            }

            if (!Regex.IsMatch(user.UserCity, UserConsts.userCity))
            {
                responce.InvalidCityFormat = true;
                responce.Successful = false;
            }
            if (!Regex.IsMatch(user.UserOrganization, UserConsts.userOrganization))
            {
                responce.InvalidOrganizationFormat = true;
                responce.Successful = false;
            }
            return responce;
        }
    }
}
