using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CenterAuth.Repositories.Authorization.Permissions.Models;

namespace CenterAuth.Repositories.Users.Models
{
    public class User
    {
        public User()
        {
            UserTypeId = null; // default value
            Emails = new List<UserEmail>();
            isActive = false;
        }

        public int Id { get; set; }

        [StringLength(100)]
        [Required]
        public string FirstName { get; set; }

        [StringLength(100)]
        [Required]
        public string LastName { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }

        public virtual ICollection<UserEmail> Emails { get; set; }

        public int? UserTypeId { get; set; }

        [ForeignKey(nameof(UserTypeId))]
        public virtual UserType? UserType { get; set; }

        public bool isActive { get; set; }
    }
}
