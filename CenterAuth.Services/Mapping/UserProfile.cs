using AutoMapper;
using CenterAuth.Repositories.Models;
using CenterAuth.Services.DTO;

namespace CenterAuth.Services.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserGet>();
            // Any other required mappings.
        }
    }

}
