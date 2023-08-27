using Microsoft.EntityFrameworkCore;
using CenterAuth.Repositories.Models;

namespace CenterAuth.Repositories
{
    public interface IAuthDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserEmail> UserEmails { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
    }
}
