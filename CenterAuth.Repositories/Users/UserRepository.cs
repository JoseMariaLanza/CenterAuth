using CenterAuth.Repositories.Users.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CenterAuth.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly IAuthDbContext _authDbContext;

        public UserRepository(AuthDbContext authDbContext)
        {
            _authDbContext = authDbContext;
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            var user = await _authDbContext.Users.FindAsync(userId);
            //var user = await _authDbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);

            if (user is null)
            {
                throw new Exception("User does not exists.");
            }

            return user;
        }

        public async Task<User> GetUserAsync(string username)
        {
            return await _authDbContext.Users.FirstOrDefaultAsync(x => x.UserName == username);
        }

        public async Task<User> CreateUserAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _authDbContext.Users.Add(user);

            await _authDbContext.SaveChangesAsync();

            return user;
        }
    }
}
