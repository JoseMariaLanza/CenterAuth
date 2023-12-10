using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;
using System.Text.Json.Serialization;
using AuthOrchestrator.Contracts;

namespace CenterAuth.Services.DTO
{
    public class UserGetDto : IUserForToken
    {
        [Required]
        [Display(Name = "User Id")]
        [SwaggerSchema("User Id")]
        public int Id { get; set; }

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
        public ICollection<IUserEmail> Emails { get; set; }

        [Display(Name = "User Type")]
        [SwaggerSchema("User type")]
        public IUserType UserType { get; set; }
    }
}
