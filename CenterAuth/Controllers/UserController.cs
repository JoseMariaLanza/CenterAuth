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
        private readonly IAuthService _authService;

        public UserController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("authenticate")]
        [SwaggerOperation(Summary = "Authenticate the user and retrieve his data.")]
        [SwaggerResponse(200, "User authenticated.", typeof(UserGet))]
        [SwaggerResponse(400, "Wrong credentials.")]
        public IActionResult Authenticate(string username, string password)
        {
            var user = _authService.Authenticate(username, password);
            if (user == null) return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }
    }
}
