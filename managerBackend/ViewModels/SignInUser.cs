using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace managerBackend.ViewModels
{
    public class SignInUser
    {
        [BindRequired]
        public string userLogin{ get; set; }
        [BindRequired]
        public string userPassword { get; set; }
    }
}
