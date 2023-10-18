using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace CenterAuth.Services.DTO
{
    public class AssignTypeDto
    {
        [Display(Name = "User Id")]
        [SwaggerSchema("User Id")]
        public int UserId { get; set; }

        [Display(Name = "User type Id")]
        [SwaggerSchema("User type Id")]
        public int UserTypeId { get; set; }
    }
}
