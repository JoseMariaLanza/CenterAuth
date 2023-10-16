using CenterAuth.Repositories.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CenterAuth.Repositories.Users
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(int userId);
        Task<User> GetUserAsync(string username);
        Task<User> CreateUserAsync(User user);
    }
}
