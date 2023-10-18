using AutoMapper;
using CenterAuth.Repositories.Users;
using CenterAuth.Repositories.Users.Models;
using CenterAuth.Services.DTO;
using Microsoft.AspNetCore.Http;

namespace CenterAuth.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;
        private readonly IMapper _mapper;  // Assuming you're using AutoMapper

        public AuthenticationService(IUserRepository userRepository, IJwtService jwtService, IMapper mapper)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
            _mapper = mapper;
        }

        public async Task<string?> AuthenticateUserAsync(string email, string password)
        {
            var user = await _userRepository.GetUserAsync(email);
            if (user is null)
                return null; // User not found

            var passwordHash = Convert.FromBase64String(user.PasswordHash);
            if (!VerifyPasswordHash(password, passwordHash, Convert.FromBase64String(user.PasswordSalt)))
                throw new BadHttpRequestException("Incorrect username or password.");
            // Use AutoMapper to map User to UserGet
            var userGet = _mapper.Map<UserGetDto>(user);

            return _jwtService.GenerateJwtToken(userGet);
        }

        public async Task<string> RegisterUserAsync(UserCreateDto userCreateDto)
        {
            var storedUser = await _userRepository.GetUserAsync(userCreateDto.UserName);

            if (storedUser is not null && storedUser.Emails.Select(ue => ue.Email).All(email => userCreateDto.Emails.Contains(email)))
            {
                return "Email already registered.";
            }

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(userCreateDto.Password, out passwordHash, out passwordSalt);

            var user = _mapper.Map<User>(userCreateDto);
            user.PasswordHash = Convert.ToBase64String(passwordHash);
            user.PasswordSalt = Convert.ToBase64String(passwordSalt);

            user.Emails = userCreateDto.Emails.Select(email => new UserEmail { Email = email }).ToList();

            var createdUser = await _userRepository.CreateUserAsync(user);

            var userGet = _mapper.Map<UserGetDto>(createdUser);

            return _jwtService.GenerateJwtToken(userGet);
        }

        public async Task<List<UserGetDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return _mapper.Map<List<UserGetDto>>(users);
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }
            return true;
        }
    }
}
