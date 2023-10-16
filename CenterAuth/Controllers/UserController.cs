using CenterAuth.Helpers;
using CenterAuth.Services;
using CenterAuth.Services.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CenterAuth.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IAuthenticationService _authService;

        public UserController(IAuthenticationService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        [SwaggerOperation(Summary = "Authenticate the user and retrieve his data.")]
        [SwaggerResponse(200, "User authenticated.", typeof(string))]
        [SwaggerResponse(400, "Wrong credentials.")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userLoginDto) // Assuming you have a UserLoginDto
        {
            var jwt = await _authService.AuthenticateUserAsync(userLoginDto.UserName, userLoginDto.Password);
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
            var jwt = await _authService.RegisterUserAsync(userCreateDto);
            if (string.IsNullOrEmpty(jwt))
                return ApiResponse.BadRequest("Registration failed. Please try again.");

            return ApiResponse.Ok("User registered and authenticated", "access_token", jwt);
        }
    }
}
