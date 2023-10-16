using CenterAuth.Repositories.Users.Models;
using CenterAuth.Services.DTO;

namespace CenterAuth.Services
{
    public interface IAuthorizationService
    {
        Task<UserTypeGetDto> AddUserTypeAsync(UserTypeCreateDto userTypeCreateDto);
        Task<List<UserTypeGetDto>> GetAllUserTypesAsync();
        Task<UserGetDto> AssignUserTypeAsync(AssignTypeDto assignTypeDto);
    }
}
