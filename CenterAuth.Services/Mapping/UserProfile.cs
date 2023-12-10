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
            // Map the User entity to the User DTO
            CreateMap<User, UserGetDto>();
            

            // Explicitly map the UserType entity to the IUserType interface for DTOs
            CreateMap<UserType, IUserType>().As<UserTypeDto>();

            // Explicitly map the UserEmail entity to the IUserEmail interface for DTOs
            CreateMap<UserEmail, IUserEmail>().As<UserEmailGetDto>();

            CreateMap<string, UserEmailGetDto>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src));

            // Map the DTOs back to entities if needed
            CreateMap<UserGetDto, User>()
                .ForMember(entity => entity.PasswordHash, opt => opt.Ignore())
                .ForMember(entity => entity.PasswordSalt, opt => opt.Ignore());

            CreateMap<UserEmail, UserEmailGetDto>();
            CreateMap<UserType, UserTypeDto>();
            CreateMap<UserTypeDto, UserType>();

            // CREATE
            CreateMap<UserCreateDto, User>()
                .ForMember(dest => dest.Emails, opt => opt.MapFrom(src => src.Emails));
            //CreateMap<UserEmail, UserEmailGetDto>();
            CreateMap<string, UserEmail>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src));

            CreateMap<UserType, UserTypeCreateDto>();
            CreateMap<UserTypeCreateDto, UserType>();
            CreateMap<AssignTypeDto, object>()
                .ConstructUsing(src => new { src.UserId, src.UserTypeId });

            //// More mappings...
            //CreateMap<User, IUserForToken>();
            ////CreateMap<User, UserGetDto>();
            //CreateMap<string, IUserEmail>()
            //    //CreateMap<string, UserEmailGetDto>()
            //    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src)).As<UserEmailGetDto>();
            ////CreateMap<string, UserEmail>()
            ////    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src));
            ////CreateMap<UserGetDto, User>()
            //CreateMap<IUserForToken, User>()
            //    .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
            //    .ForMember(dest => dest.PasswordSalt, opt => opt.Ignore());
            //CreateMap<UserCreateDto, User>()
            //    .ForMember(dest => dest.Emails, opt => opt.MapFrom(src => src.Emails));
            //CreateMap<UserUpdateDto, User>()
            //    .ForMember(dest => dest.Emails, opt => opt.MapFrom(src => src.Emails));
            //CreateMap<IUserEmail, UserEmailGetDto>();
            //CreateMap<IUserType, UserTypeDto>();
            //CreateMap<UserTypeDto, IUserType>().As<UserTypeDto>();
            ////CreateMap<UserTypeDto, IUserType>();

            ////CreateMap<UserEmail, UserEmailGetDto>();
            ////CreateMap<UserType, UserTypeDto>();
            ////CreateMap<UserTypeDto, UserType>();
            //CreateMap<UserType, UserTypeCreateDto>();
            //CreateMap<UserTypeCreateDto, UserType>();
            //CreateMap<AssignTypeDto, object>()
            //    .ConstructUsing(src => new { src.UserId, src.UserTypeId });
        }

        //public UserProfile()
        //{
        //    CreateMap<User, UserGetDto>();
        //    CreateMap<string, UserEmailGetDto>()
        //        .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src));
        //    //CreateMap<string, UserEmail>()
        //    //    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src));
        //    CreateMap<UserGetDto, User>()
        //        .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
        //        .ForMember(dest => dest.PasswordSalt, opt => opt.Ignore());
        //    CreateMap<UserCreateDto, User>()
        //        .ForMember(dest => dest.Emails, opt => opt.MapFrom(src => src.Emails));
        //    CreateMap<UserUpdateDto, User>()
        //        .ForMember(dest => dest.Emails, opt => opt.MapFrom(src => src.Emails));
        //    CreateMap<UserEmail, UserEmailGetDto>();
        //    CreateMap<UserType, UserTypeDto>();
        //    CreateMap<UserTypeDto, UserType>();
        //    CreateMap<UserType, UserTypeCreateDto>();
        //    CreateMap<UserTypeCreateDto, UserType>();
        //    CreateMap<AssignTypeDto, object>()
        //        .ConstructUsing(src => new { src.UserId, src.UserTypeId });
        //}

        //public UserProfile()
        //{
        //    // Mapping from User entity to UserGetDto
        //    CreateMap<User, UserGetDto>()
        //        .ForMember(dto => dto.Emails, opt => opt.MapFrom(u => u.Emails))
        //        .ForMember(dto => dto.UserType, opt => opt.MapFrom(u => u.UserType));

        //    // Mapping from UserCreateDto and UserUpdateDto to User
        //    CreateMap<UserCreateDto, User>()
        //        .ForMember(u => u.Emails, opt => opt.MapFrom(dto => dto.Emails.Select(e => new UserEmail { Email = e })));
        //    CreateMap<UserUpdateDto, User>()
        //        .ForMember(u => u.Emails, opt => opt.MapFrom(dto => dto.Emails.Select(e => new UserEmail { Email = e })));

        //    // Mapping for nested DTOs
        //    CreateMap<UserEmail, UserEmailGetDto>();
        //    CreateMap<UserType, UserTypeDto>();

        //    // Mapping from DTOs back to entities if needed
        //    CreateMap<UserGetDto, User>();
        //    CreateMap<UserEmailGetDto, UserEmail>();
        //    CreateMap<UserTypeDto, UserType>();

        //    // Ignore the password fields when mapping to the User entity
        //    CreateMap<UserCreateDto, User>()
        //        .ForMember(u => u.PasswordHash, opt => opt.Ignore())
        //        .ForMember(u => u.PasswordSalt, opt => opt.Ignore());
        //    CreateMap<UserUpdateDto, User>()
        //        .ForMember(u => u.PasswordHash, opt => opt.Ignore())
        //        .ForMember(u => u.PasswordSalt, opt => opt.Ignore());

        //    // Add any other mappings here
        //}

        //public UserProfile()
        //{
        //    CreateMap<User, IUserForToken>();
        //    //CreateMap<User, UserGetDto>();
        //    CreateMap<string, IUserEmail>()
        //    //CreateMap<string, UserEmailGetDto>()
        //        .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src)).As<UserEmailGetDto>();
        //    //CreateMap<string, UserEmail>()
        //    //    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src));
        //    //CreateMap<UserGetDto, User>()
        //    CreateMap<IUserForToken, User>()
        //        .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
        //        .ForMember(dest => dest.PasswordSalt, opt => opt.Ignore());
        //    CreateMap<UserCreateDto, User>()
        //        .ForMember(dest => dest.Emails, opt => opt.MapFrom(src => src.Emails));
        //    CreateMap<UserUpdateDto, User>()
        //        .ForMember(dest => dest.Emails, opt => opt.MapFrom(src => src.Emails));
        //    CreateMap<IUserEmail, UserEmailGetDto>();
        //    CreateMap<IUserType, UserTypeDto>();
        //    CreateMap<UserTypeDto, IUserType>().As<UserTypeDto>();
        //    //CreateMap<UserTypeDto, IUserType>();

        //    //CreateMap<UserEmail, UserEmailGetDto>();
        //    //CreateMap<UserType, UserTypeDto>();
        //    //CreateMap<UserTypeDto, UserType>();
        //    CreateMap<UserType, UserTypeCreateDto>();
        //    CreateMap<UserTypeCreateDto, UserType>();
        //    CreateMap<AssignTypeDto, object>()
        //        .ConstructUsing(src => new { src.UserId, src.UserTypeId });
        //}
    }
}
