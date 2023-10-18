using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;
using System.Text.Json.Serialization;

namespace CenterAuth.Services.DTO
{
    public class UserGetDto
    {
        [Required]
        [Display(Name = "First Name")]
        [SwaggerSchema("First Name of the User")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [SwaggerSchema("Last Name of the User")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "User Name")]
        [SwaggerSchema("User Name of the User")]
        public string UserName { get; set; }

        [Display(Name = "User Emails")]
        [SwaggerSchema("Collection of the emails asociated to one User")]
        public virtual ICollection<UserEmailGetDto> Emails { get; set; }
        //public string[] AssociatedEmails => Emails.Select(e => e.Email).ToArray();

        [Display(Name = "User Type")]
        [SwaggerSchema("User type")]
        public virtual UserTypeDto UserType { get; set; }
    }
}
