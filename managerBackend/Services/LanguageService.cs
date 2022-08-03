namespace managerBackend.Services
{
    public class LanguageService : ILanguageService
    {
        IHttpContextAccessor httpContextAccessor;
        IConfiguration appConfig;
        public LanguageService(IHttpContextAccessor httpContextAccessor, IConfiguration appConfig)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.appConfig = appConfig ?? throw new ArgumentNullException(nameof(appConfig));
        }
        public bool SetLanguage()
        {
            if (httpContextAccessor.HttpContext == null) throw new ArgumentNullException(nameof(httpContextAccessor));
            if (httpContextAccessor.HttpContext.Request.Headers.ContainsKey("Accept-Language"))
            {
                var acceptLanguage = httpContextAccessor.HttpContext.Request.Headers["Accept-Language"];

                SetCookie(GetPreferredLanguage(acceptLanguage));
                return true;
            }
            return false;
        }

        private void SetCookie(String currentLanguge)
        {
            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.UtcNow.AddDays(28)
            };
            httpContextAccessor.HttpContext!.Response.Cookies.Append("lang", currentLanguge, cookieOptions);
        }

        private string GetPreferredLanguage(string acceptLanguage)
        {
            string responce = acceptLanguage.Split(',')[0].Split('-')[0];
            if (!CheckOfExist(responce))
            {
                int i = acceptLanguage.IndexOf(',');
                acceptLanguage = acceptLanguage.Substring(i + 1);
                foreach (var item in acceptLanguage.Split(','))
                {
                    string lang = item.Split(';')[0].Split('-')[0];
                    if (!CheckOfExist(lang))
                    {
                        return lang;
                    }
                }
                return appConfig.GetSection("Language:DefaultLanguage").Value;
            }
            return responce;
        }

        private bool CheckOfExist(string lang)
        {
            foreach (var item in appConfig.GetSection("Language").GetChildren())
            {
                if (item.Value == lang)
                {
                    return true;
                }
            }
            return false;
        }
    }
    public static class LanguageExtensions
    {
        public static void AddLanguageService(this IServiceCollection services)
        {
            services.AddScoped<ILanguageService, LanguageService>();
        }
    }
}
