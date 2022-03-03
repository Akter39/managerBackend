using Microsoft.AspNetCore.Mvc.ModelBinding;
namespace managerBackend.Models
{
   public class User
    {
        [BindNever]
        public int Id { get; set; }
        [BindRequired]
        public string userName { get; set; }
        [BindRequired]
        public string userPassword { get; set; }
        [BindRequired]
        public string userConfirmPassword { get; set; }
        [BindRequired]
        public string userEmail { get; set; }
        [BindRequired]
        public string userPhone { get; set; }
        [BindRequired]
        public string userCity { get; set; }
        [BindRequired]
        public string userOrganization { get; set; }
    }
}
