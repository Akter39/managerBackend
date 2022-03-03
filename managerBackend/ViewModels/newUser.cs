using managerBackend.Models;

using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace managerBackend.ViewModels
{
    public class newUser : User//, ICloneable
    {
        [BindRequired]
        public string userConfirmPassword { get; set; }
    }
}
