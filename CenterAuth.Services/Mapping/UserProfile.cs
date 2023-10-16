﻿using AutoMapper;
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
            CreateMap<UserCreateDto, User>()
                .ForMember(dest => dest.FirstName, opt => opt.Ignore())
                .ForMember(dest => dest.LastName, opt => opt.Ignore())
                .ForMember(dest => dest.UserName, opt => opt.Ignore())
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
                .ForMember(dest => dest.PasswordSalt, opt => opt.Ignore())
                .ForMember(dest => dest.Emails, opt => opt.MapFrom(src => src.Emails));
            CreateMap<UserUpdateDto, User>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.FirstName, opt => opt.Ignore())
                .ForMember(dest => dest.LastName, opt => opt.Ignore())
                .ForMember(dest => dest.UserName, opt => opt.Ignore())
                //.ForMember(dest => dest.Emails, opt=>)
                .ForMember(dest => dest.UserTypeId, opt => opt.Ignore());
            CreateMap<UserEmail, UserEmailGetDto>();
            CreateMap<UserType, UserTypeGetDto>();
        }
    }
}
