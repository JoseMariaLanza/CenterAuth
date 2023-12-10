using AuthOrchestrator.Contracts;
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
            // GET
            CreateMap<User, UserGetDto>();

            // Explicitly map the UserType entity to the IUserType interface for DTOs
            CreateMap<UserType, IUserType>().As<UserTypeDto>();

            // Explicitly map the UserEmail entity to the IUserEmail interface for DTOs
            CreateMap<UserEmail, IUserEmail>().As<UserEmailGetDto>();

            CreateMap<string, UserEmailGetDto>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src));
            CreateMap<UserGetDto, User>()
                .ForMember(entity => entity.PasswordHash, opt => opt.Ignore())
                .ForMember(entity => entity.PasswordSalt, opt => opt.Ignore());

            CreateMap<UserEmail, UserEmailGetDto>();
            CreateMap<UserType, UserTypeDto>();
            CreateMap<UserTypeDto, UserType>();

            // CREATE
            CreateMap<UserCreateDto, User>()
                .ForMember(dest => dest.Emails, opt => opt.MapFrom(src => src.Emails));
            CreateMap<string, UserEmail>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src));

            CreateMap<UserType, UserTypeCreateDto>();
            CreateMap<UserTypeCreateDto, UserType>();
            CreateMap<AssignTypeDto, object>()
                .ConstructUsing(src => new { src.UserId, src.UserTypeId });
        }
    }
}
