using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace managerBackend.ViewModels
{
    public class SignInUser
    {
        [BindRequired]
        public string UserLogin{ get; set; }
        [BindRequired]
        public string UserPassword { get; set; }
    }
}
