using CenterAuth.Helpers;
using CenterAuth.Services;
using CenterAuth.Services.DTO;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CenterAuth.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorizationController : Controller
    {
        private readonly IAuthorizationService _authService;

        public AuthorizationController(IAuthorizationService authService)
        {
            _authService = authService;
        }

        [HttpPost("user-type")]
        [SwaggerOperation(Summary = "Add a new user type.")]
        [SwaggerResponse(201, "User type created successfully.")]
        [SwaggerResponse(400, "Failed to create user type.")]
        public async Task<IActionResult> AddUserType([FromBody] UserTypeCreateDto userTypeCreateDto)
        {
            var result = await _authService.AddUserTypeAsync(userTypeCreateDto);
            if (result is null)
                return ApiResponse.BadRequest("Failed to create user type.");

            return ApiResponse.Created("User type created successfully.");
        }

        [HttpGet("user-types")]
        [SwaggerOperation(Summary = "Get all user types.")]
        [SwaggerResponse(200, "Successfully retrieved user types.", typeof(List<UserTypeGetDto>))]
        public async Task<IActionResult> GetUserTypes()
        {
            var userTypes = await _authService.GetAllUserTypesAsync();

            if (userTypes is null)
            {
                return ApiResponse.NoContent();
            }
            return ApiResponse.Ok("Successfully retrieved user types.", "UserTypes", userTypes);
        }

        [HttpPut("assign-type/{userId}")]
        [SwaggerOperation(Summary = "Assign a user type to a specific user.")]
        [SwaggerResponse(200, "User type assigned successfully.")]
        [SwaggerResponse(400, "Failed to assign user type.")]
        public async Task<IActionResult> AssignUserType(int userId, [FromBody] AssignTypeDto assignTpeDto)
        {
            var result = await _authService.AssignUserTypeAsync(assignTpeDto);

            if ( result is null)
            {
                return ApiResponse.BadRequest("Failed to assign user type.");
            }

            return ApiResponse.Ok("User type assigned successfully.");
        }
    }
}
