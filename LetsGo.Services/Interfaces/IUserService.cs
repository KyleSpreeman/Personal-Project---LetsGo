using LetsGo.Models;
using LetsGo.Models.Requests;

namespace LetsGo.Services
{
    public interface IUserService
    {
        int Create(object userModel);
        bool LogIn(string email, string password);
        bool LogInTest(string email, string password, int id, string[] roles = null);
        int Register(UserRegisterRequest userRegisterRequest);
        IUserAuthData ActualLogin(UserLoginRequest userLoginRequest);
        bool Logout();
    }
}
