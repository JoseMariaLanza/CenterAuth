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

            modelBuilder.Entity<UserType>().HasData(
                new UserType { Id = 1, Name = "Admin", Type = "/1/" },
                new UserType { Id = 2, Name = "Staff", Type = "/2/" },
                new UserType { Id = 3, Name = "Management", Type = "/2/1/" },
                new UserType { Id = 4, Name = "SiteAdmin", Type = "/2/1/1/" },
                new UserType { Id = 5, Name = "Director", Type = "/2/1/2/" },
                new UserType { Id = 6, Name = "Manager", Type = "/2/1/3/" },
                new UserType { Id = 7, Name = "OperationsManager", Type = "/2/1/4/" },
                new UserType { Id = 8, Name = "AdministrativeAssistant", Type = "/2/1/5/" },
                new UserType { Id = 9, Name = "HR", Type = "/2/2/" },
                new UserType { Id = 10, Name = "ITSupport", Type = "/2/3/" },
                new UserType { Id = 11, Name = "Finance", Type = "/2/4/" },
                new UserType { Id = 12, Name = "Architect", Type = "/3/" },
                new UserType { Id = 13, Name = "SecuritySpecialist", Type = "/4/" },
                new UserType { Id = 14, Name = "NetworkEngineer", Type = "/5/" },
                new UserType { Id = 15, Name = "SupportEngineer", Type = "/6/" },
                new UserType { Id = 16, Name = "ITAdministrator", Type = "/7/" },
                new UserType { Id = 17, Name = "SME", Type = "/8/" },
                new UserType { Id = 18, Name = "TeamMember", Type = "/9/" },
                new UserType { Id = 19, Name = "ProjectManager", Type = "/9/1/" },
                new UserType { Id = 20, Name = "TeamLead", Type = "/9/2/" },
                new UserType { Id = 21, Name = "Developer", Type = "/9/3/" },
                new UserType { Id = 22, Name = "FrontendDeveloper", Type = "/9/3/1/" },
                new UserType { Id = 23, Name = "BackendDeveloper", Type = "/9/3/2/" },
                new UserType { Id = 24, Name = "QAEngineer", Type = "/9/4/" },
                new UserType { Id = 25, Name = "UXDesigner", Type = "/9/5/" },
                new UserType { Id = 26, Name = "ProductOwner", Type = "/9/6/" },
                new UserType { Id = 27, Name = "DevOpsEngineer", Type = "/9/7/" },
                new UserType { Id = 28, Name = "DataScientist", Type = "/9/8/" }
            );

            modelBuilder.Entity<User>()
                .Property(u => u.UserTypeId)
                .HasDefaultValue(null);
        }
    }
}
