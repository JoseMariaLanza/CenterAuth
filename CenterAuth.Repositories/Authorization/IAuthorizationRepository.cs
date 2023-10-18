using CenterAuth.Repositories.Authorization.Permissions.Models;
using CenterAuth.Repositories.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CenterAuth.Repositories.Authorization
{
    public interface IAuthorizationRepository
    {
        Task<UserType?> GetUserTypeByName(string name);
        Task<UserType> AddUserTypeAsync(UserType userType);
        Task<List<UserType>> GetAllUserTypesAsync();
        Task<User> AssignUserTypeAsync(User user);
    }
}
