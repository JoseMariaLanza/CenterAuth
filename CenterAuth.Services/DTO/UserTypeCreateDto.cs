using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace CenterAuth.Services.DTO
{
    public class UserTypeCreateDto
    {
        [Display(Name = "User Type Name")]
        [SwaggerSchema("User type name")]
        public string Name { get; set; }

        [Display(Name = "User Type")]
        [SwaggerSchema("User type")]
        public string Type { get; set; }
    }
}
