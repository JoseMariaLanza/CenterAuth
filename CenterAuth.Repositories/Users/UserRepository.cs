using CenterAuth.Repositories.Models;
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

        public async Task<User> GetUserAsync(string username, string password)
        {
            return await _authDbContext.Users.FirstOrDefaultAsync(x => x.UserName == username && x.Password == password);
        }
    }
}
