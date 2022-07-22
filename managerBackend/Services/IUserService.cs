using managerBackend.Models;

namespace managerBackend.Services
{
    public interface IUserService
    {
        public Task<bool> NewUser(User user, string defaultRole);
        public Task SignIn<T>(T responce, User user, string ip);
        public Task<T> RefreshJwt<T>(User user, string ip);
        public Task<bool> RevokeJwt(string jwt, string ip);
        public string IpAddress();
        public void setTokenCookie(string token);
    }
}
