using AutoMapper;
using CenterAuth.Repositories.Users;
using CenterAuth.Services.DTO;

namespace CenterAuth.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;  // Assuming you're using AutoMapper

        public AuthService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public UserGet Authenticate(string username, string password)
        {
            var user = _userRepository.GetUserAsync(username, password);
            if (user == null)
                return null;

            // Use AutoMapper to map User to UserGet
            var userGet = _mapper.Map<UserGet>(user);

            return userGet;
        }
    }
}
