using CenterAuth.Repositories.Models;
using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;
using System.Text.Json.Serialization;

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
        [JsonIgnore]
        public virtual ICollection<UserEmailGet> Emails { get; set; }
        public string[] AssociatedEmails => Emails.Select(e => e.Email).ToArray();

        [Display(Name = "User Type")]
        [SwaggerSchema("User type")]
        public virtual UserTypeGet UserType { get; set; }
    }
}
