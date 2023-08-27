using CenterAuth.Services.DTO;

namespace CenterAuth.Services
{
    public interface IAuthService
    {
        UserGet Authenticate(string username, string password);
    }
}
