using Microsoft.AspNetCore.Mvc.ModelBinding;

using System.ComponentModel.DataAnnotations.Schema;

namespace managerBackend.Models
{
    public class User
    {
        [BindNever]
        public int Id { get; set; }
        [BindRequired]
        public string UserNickname { get; set; }
        [BindRequired]
        public string UserName { get; set; }
        [BindRequired]
        public string UserPassword { get; set; }
        [BindRequired, NotMapped]
        public string UserConfirmPassword { get; set; }
        [BindRequired]
        public string UserEmail { get; set; }
        [BindRequired]
        public string UserPhone { get; set; }
        [BindRequired]
        public string UserCity { get; set; }
        [BindRequired]
        public string UserOrganization { get; set; }
        [BindNever]
        public List<Role> Roles { get; set; } = new();
    }
}
