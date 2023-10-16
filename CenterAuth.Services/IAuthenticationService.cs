using CenterAuth.Services.DTO;

namespace CenterAuth.Services
{
    public interface IAuthenticationService
    {
        Task<string?> AuthenticateUserAsync(string email, string password);
        Task<string> RegisterUserAsync(UserCreateDto userDto);
    }
}
