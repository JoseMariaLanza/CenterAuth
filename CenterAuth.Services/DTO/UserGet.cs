using CenterAuth.Repositories.Models;
using System.ComponentModel.DataAnnotations;

namespace CenterAuth.Services.DTO
{
    public class UserGet
    {
        [Required]
        [Display(Name = "First Name")]
        public int FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "User Emails")]
        public virtual ICollection<UserEmail> Emails { get; set; }

        [Display(Name = "User Type")]
        public virtual UserType UserType { get; set; }
    }
}
