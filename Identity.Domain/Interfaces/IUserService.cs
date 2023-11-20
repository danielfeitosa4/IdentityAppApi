using Identity.Domain.Models;

namespace Identity.Domain.Interfaces
{
    public interface IUserService
    {
        Task<string> Create(UserModel userModel);
    }
}
