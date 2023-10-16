using Microsoft.EntityFrameworkCore;
using CenterAuth.Repositories.Users.Models;
using CenterAuth.Repositories.Authorization.Permissions.Models;

namespace CenterAuth.Repositories
{
    public interface IAuthDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserEmail> UserEmails { get; set; }
        public DbSet<UserType> UserTypes { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
