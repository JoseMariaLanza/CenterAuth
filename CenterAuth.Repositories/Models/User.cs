using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CenterAuth.Repositories.Models
{
    public class User
    {
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
        [MinLength(6)]
        public string Password { get; set; }

        public virtual ICollection<UserEmail> Emails { get; set; }

        [Required]
        public int UserTypeId { get; set; }

        [ForeignKey(nameof(UserTypeId))]
        public virtual UserType UserType { get; set; }
    }
}
 