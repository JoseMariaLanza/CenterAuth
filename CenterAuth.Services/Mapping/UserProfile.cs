using AutoMapper;
using CenterAuth.Repositories.Authorization.Permissions.Models;
using CenterAuth.Repositories.Users.Models;
using CenterAuth.Services.DTO;

namespace CenterAuth.Services.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserGetDto>();
            CreateMap<string, UserEmail>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src));
            CreateMap<UserGetDto, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
                .ForMember(dest => dest.PasswordSalt, opt => opt.Ignore());
            CreateMap<UserCreateDto, User>()
                .ForMember(dest => dest.Emails, opt => opt.MapFrom(src => src.Emails));
            CreateMap<UserUpdateDto, User>()
                .ForMember(dest => dest.Emails, opt => opt.MapFrom(src => src.Emails));
            CreateMap<UserEmail, UserEmailGetDto>();
            CreateMap<UserType, UserTypeDto>();
            CreateMap<UserTypeDto, UserType>();
            CreateMap<UserType, UserTypeCreateDto>();
            CreateMap<UserTypeCreateDto, UserType>();
            CreateMap<AssignTypeDto, object>()
                .ConstructUsing(src => new { src.UserId, src.UserTypeId });
        }
    }
}
