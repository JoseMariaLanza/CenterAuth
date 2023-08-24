using Microsoft.EntityFrameworkCore;
using CenterAuth.Repositories.Models;

namespace CenterAuth.Repositories
{
    public class AuthDbContext : DbContext, IAuthDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
