using CenterAuth.Repositories.Users.Models;
using CenterAuth.Services.DTO;

namespace CenterAuth.Services
{
    public interface IAuthorizationManagementService
    {
        Task<List<UserTypeDto>> GetAllUserTypesAsync();
        Task<UserTypeDto> AddUserTypeAsync(UserTypeCreateDto userTypeCreateDto);
        Task<UserTypeDto> UpdateUserTypeAsync(UserTypeDto userTypeCreateDto);
        Task<UserGetDto> AssignUserTypeAsync(AssignTypeDto assignTypeDto);
    }
}
