using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace CenterAuth.Services.DTO
{
    public class UserEmailGetDto
    {
        [Display(Name = "User Email")]
        [SwaggerSchema("User email")]
        public string Email { get; set; }
    }
}
