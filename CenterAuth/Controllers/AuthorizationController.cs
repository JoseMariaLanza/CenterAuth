using CenterAuth.Helpers;
using CenterAuth.Services;
using CenterAuth.Services.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using CenterAuth.Constants;

namespace CenterAuth.Controllers
{
    [Authorize(Roles = UserTypes.Admin.HierarchyNode)]
    [ApiController]
    [Route("[controller]")]
    public class AuthorizationController : Controller
    {
        private readonly IAuthorizationManagementService _authorizationManagementService;

        public AuthorizationController(IAuthorizationManagementService authorizationManagementService)
        {
            _authorizationManagementService = authorizationManagementService;
        }

        [HttpGet("user-types")]
        [SwaggerOperation(Summary = "Get all user types.")]
        [SwaggerResponse(200, "Successfully retrieved user types.", typeof(List<UserTypeDto>))]
        public async Task<IActionResult> GetUserTypes()
        {
            var userTypes = await _authorizationManagementService.GetAllUserTypesAsync();

            if (userTypes is null)
            {
                return ApiResponse.NoContent();
            }
            return ApiResponse.Ok("Successfully retrieved user types.", "UserTypes", userTypes);
        }

        [HttpPost("user-type")]
        [SwaggerOperation(Summary = "Add a new user type.")]
        [SwaggerResponse(201, "User type created successfully.")]
        [SwaggerResponse(400, "Failed to create user type.")]
        public async Task<IActionResult> AddUserType([FromBody] UserTypeCreateDto userTypeCreateDto)
        {
            var result = await _authorizationManagementService.AddUserTypeAsync(userTypeCreateDto);
            if (result is null)
                return ApiResponse.BadRequest("Failed to create user type.");

            return ApiResponse.Created("User type created successfully.", "UserType", result);
        }

        [HttpPut("user-type")]
        [SwaggerOperation(Summary = "Add a new user type.")]
        [SwaggerResponse(200, "User type updated successfully.")]
        [SwaggerResponse(400, "Failed to update user type.")]
        public async Task<IActionResult> UpdateUserType([FromBody] UserTypeDto userTypeUpdateDto)
        {
            var result = await _authorizationManagementService.UpdateUserTypeAsync(userTypeUpdateDto);
            if (result is null)
                return ApiResponse.BadRequest("Failed to create user type.");

            return ApiResponse.Ok("User type updated successfully.", "UserType", result);
        }

        [HttpPut("assign-user-type")]
        [SwaggerOperation(Summary = "Assign a user type to a specific user.")]
        [SwaggerResponse(200, "User type assigned successfully.")]
        [SwaggerResponse(400, "Failed to assign user type.")]
        public async Task<IActionResult> AssignUserType([FromBody] AssignTypeDto assignTypeDto)
        {
            var result = await _authorizationManagementService.AssignUserTypeAsync(assignTypeDto);

            if ( result is null)
            {
                return ApiResponse.BadRequest("Failed to assign user type.");
            }

            return ApiResponse.Ok("User type assigned successfully.", "UpdatedUser", result);
        }
    }
}
