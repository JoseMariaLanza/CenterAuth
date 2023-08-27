using CenterAuth.Repositories.Models;
using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace CenterAuth.Services.DTO
{
    public class UserGet
    {
        [Required]
        [Display(Name = "First Name")]
        [SwaggerSchema("First Name of the User")]
        public int FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [SwaggerSchema("Last Name of the User")]
        public string LastName { get; set; }

        [Display(Name = "User Emails")]
        [SwaggerSchema("Collection of the emails asociated to one User")]
        public virtual ICollection<UserEmail> Emails { get; set; }

        [Display(Name = "User Type")]
        [SwaggerSchema("User type")]
        public virtual UserType UserType { get; set; }
    }
}
