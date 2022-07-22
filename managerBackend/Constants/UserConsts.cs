namespace managerBackend.Constants
{
    public class UserConsts
    {
            public const string userName = @"^([a-zA-Z])(\w{3,13})([a-zA-Z0-9])$";
            public const string userPassword = @"^\w{6,20}$";
            public const string userPhone = @"^(\+?\d{1,2})?(\s|-)?((\(\d{3}\))|(\d{3}))(\s|-)?(\d{3})(\s|-)?(\d{2})(\s|-)?(\d{2})$";
            public const string userCity = @"^[a-zA-Zа-яА-Я\s\-]{1,20}$";
            public const string userOrganization = @"^[a-zA-Zа-яА-Я0-9\'\u0022\s\-]{2,30}$";
            public const string userEmail = @"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z])+$";
    }
}
