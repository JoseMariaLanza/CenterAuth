using AutoMapper;
using CenterAuth.Repositories.Authorization;
using CenterAuth.Repositories.Authorization.Permissions.Models;
using CenterAuth.Repositories.Users;
using CenterAuth.Services.DTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CenterAuth.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IAuthorizationRepository _authorizationRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public AuthorizationService(IAuthorizationRepository authorizationRepository, IUserRepository userRepository, IMapper mapper)
        {
            _authorizationRepository = authorizationRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserTypeGetDto> AddUserTypeAsync(UserTypeCreateDto userTypeCreateDto) 
        {
            var storedUserType = await _authorizationRepository.GetUserTypeByName(userTypeCreateDto.Name);

            //if (storedUserType is not null)
            //{
            //    throw new BadHttpRequestException("User type already exists.");
            //}

            var newUserType = _mapper.Map<UserType>(userTypeCreateDto);
            var createdUserType = await _authorizationRepository.AddUserTypeAsync(newUserType);

            return _mapper.Map<UserTypeGetDto>(createdUserType);
        }
        public async Task<List<UserTypeGetDto>> GetAllUserTypesAsync()
        {
            var users = await _authorizationRepository.GetAllUserTypesAsync();
            return _mapper.Map<List<UserTypeGetDto>>(users);
        }
        public async Task<UserGetDto> AssignUserTypeAsync(AssignTypeDto assignTypeDto)
        {
            var user = await _userRepository.GetUserByIdAsync(assignTypeDto.UserId);

            var updatedUser = _authorizationRepository.AssignUserTypeAsync(user);

            return _mapper.Map<UserGetDto>(updatedUser);
        }
    }
}
