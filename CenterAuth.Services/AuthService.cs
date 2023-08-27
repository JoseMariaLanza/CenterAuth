using AutoMapper;
using CenterAuth.Repositories;
using CenterAuth.Services.DTO;

namespace CenterAuth.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthDbContext _dbContext;
        private readonly IMapper _mapper;  // Assuming you're using AutoMapper

        public AuthService(IAuthDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public UserGet Authenticate(string username, string password)
        {
            // Your authentication logic here.
        }
    }
}
