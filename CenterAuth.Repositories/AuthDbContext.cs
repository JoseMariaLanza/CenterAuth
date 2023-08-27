using Microsoft.EntityFrameworkCore;
using CenterAuth.Repositories.Models;

namespace CenterAuth.Repositories
{
    public class AuthDbContext : DbContext, IAuthDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserEmail> UserEmails { get; set; }
        public DbSet<UserType> UserTypes { get; set; }

        public AuthDbContext(DbContextOptions<AuthDbContext> options)
            : base(options)
        {
        }
    }
}
