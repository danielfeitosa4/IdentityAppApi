using Identity.Domain.Models;

namespace Identity.Domain.Interfaces
{
    public interface IAccountService
    {
        Task<string> Login(LoginModel loginModel);
    }
}
