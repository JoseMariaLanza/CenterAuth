using System.ComponentModel.DataAnnotations;
using AuthOrchestrator.Contracts;
using Swashbuckle.AspNetCore.Annotations;

namespace CenterAuth.Services.DTO
{
    public class UserEmailGetDto : IUserEmail
    {
        [Display(Name = "User Email")]
        [SwaggerSchema("User email")]
        public string Email { get; set; }
    }
}
