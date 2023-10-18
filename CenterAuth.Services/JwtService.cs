using Microsoft.Extensions.Configuration;
using CenterAuth.Services.Models;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using CenterAuth.Services.DTO;

namespace CenterAuth.Services
{
    public class JwtService : IJwtService
    {
        private readonly JwtSettings _jwtSettings;

        public JwtService(IConfiguration configuration)
        {
            _jwtSettings = configuration.GetSection("JwtSettings").Get<JwtSettings>();
        }

        public string GenerateJwtToken(UserGetDto user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.FirstName + " " + user.LastName),
                new Claim("FirstName", user.FirstName),
                new Claim("LastName", user.LastName),
                new Claim("UserName", user.UserName),
                //new Claim(ClaimTypes.Role, user.UserType?.Type ?? "Guest")
                //new Claim(ClaimTypes.Name, user.UserName),
                //new Claim(ClaimTypes.Role, user.UserType?.Type ?? "Guest")
            };

            //foreach(var email in user.AssociatedEmails)
            //{
            //    claims.Add(new Claim("Email", email));
            //}

            if (user.UserType is not null)
            {
                claims.Add(new Claim("UserTypeId", user.UserType.Id.ToString()));
                claims.Add(new Claim(ClaimTypes.Role, user.UserType.Type));
                //claims.Add(new Claim(ClaimTypes.Role, user.UserType?.Type ?? "Guest" ));
                //claims.Add(new Claim("UserType", user.UserType.Type));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var expires = DateTime.Now.AddMinutes(_jwtSettings.DurationInMinutes);

            var token = new JwtSecurityToken(
                _jwtSettings.Issuer,
                _jwtSettings.Audience,
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
