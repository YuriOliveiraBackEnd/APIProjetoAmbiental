using APIAmbiental.Models;

namespace APIAmbiental.Services
{
    public interface IAuthService
    {
        UserModel Authenticate(string username, string password);

    }
}
