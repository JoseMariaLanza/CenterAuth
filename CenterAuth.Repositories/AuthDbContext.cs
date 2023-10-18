using Microsoft.EntityFrameworkCore;
using CenterAuth.Repositories.Users.Models;
using CenterAuth.Repositories.Authorization.Permissions.Models;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserEmail>()
                .HasKey(ue => new { ue.UserId, ue.Email });

            modelBuilder.Entity<UserType>().HasData(new UserType { Id = 1, Name = "Admin", Type = "/1/" });
            modelBuilder.Entity<UserType>().HasData(new UserType { Id = 2, Name = "Staff", Type = "/2/" });

            modelBuilder.Entity<User>()
                .Property(u => u.UserTypeId)
                .HasDefaultValue(null);
        }
    }
}
