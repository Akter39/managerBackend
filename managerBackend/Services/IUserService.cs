using managerBackend.Models;
using managerBackend.ViewModels;

namespace managerBackend.Services
{
    public interface IUserService<T> where T : class
    {
        public Task<bool> NewUser(User user, string defaultRole);
        public Task<T> SignIn(T responce, User user, string ip);
        public Task<T> RefreshJwt(string jwt, string ip);
        public Task<bool> RevokeJwt(string jwt, string ip);
        public string IpAddress();
        public void setTokenCookie(string token);
        public Task<UserInfo> GetUser(int id);
    }
}
