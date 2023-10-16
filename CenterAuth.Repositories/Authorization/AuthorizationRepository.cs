using CenterAuth.Repositories.Authorization.Permissions.Models;
using CenterAuth.Repositories.Users.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CenterAuth.Repositories.Authorization
{
    public class AuthorizationRepository : IAuthorizationRepository
    {
        private readonly IAuthDbContext _authDbContext;

        public AuthorizationRepository(AuthDbContext authDbContext)
        {
            _authDbContext = authDbContext;
        }

        public async Task<UserType?> GetUserTypeByName(string name)
        {
            var userType = await _authDbContext.UserTypes.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());
            if (userType is null)
            {
                return null;
            }
            return userType;
        }

        public async Task<UserType> AddUserTypeAsync(UserType userType)
        {
            _authDbContext.UserTypes.Add(userType);

            await _authDbContext.SaveChangesAsync();
            return userType;
        }

        public async Task<List<UserType>> GetAllUserTypesAsync()
        {

            return await _authDbContext.UserTypes.ToListAsync();
        }

        public async Task<User> AssignUserTypeAsync(User user)
        {
            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _authDbContext.Users.Update(user);

            await _authDbContext.SaveChangesAsync();

            return user;
        }
    }
}
