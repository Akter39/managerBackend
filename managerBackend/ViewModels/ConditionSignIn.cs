using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace managerBackend.ViewModels
{
    public class ConditionSignIn
    {
        public bool Successful { get; set; } = true;
        public bool InvalidSignIn { get; set; } = false;
        public bool InvalidLoginFormat { get; set; } = false;
        public bool InvalidPasswordFormat { get; set; } = false;
        public CurrentUser? CurrentUser { get; set; }
    }
}
