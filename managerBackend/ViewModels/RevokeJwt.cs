using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace managerBackend.ViewModels
{
    public class RevokeJwt
    {
        [BindingBehavior(BindingBehavior.Optional)]

        public string Jwt { get; set; }
    }
}
