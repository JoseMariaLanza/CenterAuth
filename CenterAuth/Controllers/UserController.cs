using CenterAuth.Constants;
using CenterAuth.Helpers;
using CenterAuth.Services;
using CenterAuth.Services.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CenterAuth.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IAuthenticationService _authenticationService;

        public UserController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("login")]
        [SwaggerOperation(Summary = "Authenticate the user and retrieve his data.")]
        [SwaggerResponse(200, "User authenticated.", typeof(string))]
        [SwaggerResponse(400, "Wrong credentials.")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userLoginDto) // Assuming you have a UserLoginDto
        {
            var jwt = await _authenticationService.AuthenticateUserAsync(userLoginDto.UserName, userLoginDto.Password);
            if (string.IsNullOrEmpty(jwt))
                return ApiResponse.NotFound("User does not exists.");

            return ApiResponse.Ok("User authenticated.", "access_token", jwt);
        }

        [HttpPost("create")]
        [SwaggerOperation(Summary = "Create a user account, authenticate and retrieve his data.")]
        [SwaggerResponse(200, "User authenticated.", typeof(string))]
        [SwaggerResponse(400, "Registration failed.")]
        public async Task<IActionResult> Register([FromBody] UserCreateDto userCreateDto)
        {
            var jwt = await _authenticationService.RegisterUserAsync(userCreateDto);
            if (string.IsNullOrEmpty(jwt))
                return ApiResponse.BadRequest("Registration failed. Please try again.");

            return ApiResponse.Ok("User registered and authenticated", "access_token", jwt);
        }

        [Authorize(Policy = "AdminOrSiteAdmin")]
        [HttpGet("user-list")]
        [SwaggerOperation(Summary = "Retrieve all registered users.")]
        [SwaggerResponse(200, "Users retrieved successfully.", typeof(string))]
        [SwaggerResponse(400, "Registration failed.")]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _authenticationService.GetAllUsersAsync();
            if (result is null)
                return ApiResponse.NoContent();

            return ApiResponse.Ok("Users retrieved successfully.", "users", result);
        }
    }
}
