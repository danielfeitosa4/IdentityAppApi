using Identity.Domain.Models;

namespace Identity.Domain.Interfaces
{
    public interface IKeycloakService
    {
        Task<string> Token();
    }
}
