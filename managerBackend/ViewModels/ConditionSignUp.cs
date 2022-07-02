using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace managerBackend.ViewModels
{
    public class ConditionSignUp
    {
        public bool Successful { get; set; } = true;
        public bool NameBusy { get; set; } = false;
        public bool NicknameBusy { get; set; } = false;
        public bool EmailBusy { get; set; } = false;
        public bool PhoneBusy { get; set; } = false;
        public bool NotMatchPasswords { get; set; } = false;
        public bool MatchName { get; set; } = false;
        public bool InvalidNameFormat { get; set; } = false;
        public bool InvalidNicknameFormat { get; set; } = false;
        public bool InvalidEmailFormat { get; set; } = false;
        public bool InvalidPhoneFormat { get; set; } = false;
        public bool InvalidPasswordFormat { get; set; } = false;
        public bool InvalidCityFormat { get; set; } = false;
        public bool InvalidOrganizationFormat { get; set; } = false;
    }
}
