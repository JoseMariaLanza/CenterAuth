using CenterAuth.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CenterAuth.Repositories.Users
{
    public interface IUserRepository
    {
        public Task<User> GetUserAsync(string username, string password);
    }
}
