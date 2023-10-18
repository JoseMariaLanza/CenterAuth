using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace CenterAuth.Services.DTO
{
    public class UserTypeDto
    {

        [Required]
        [Display(Name = "User Type Id")]
        [SwaggerSchema("User type Id")]
        public int Id { get; set; }

        [Display(Name = "User Type Name")]
        [SwaggerSchema("User type name")]
        public string Name { get; set; }

        [Display(Name = "User Type")]
        [SwaggerSchema("User type")]
        public string Type { get; set; }
    }
}
