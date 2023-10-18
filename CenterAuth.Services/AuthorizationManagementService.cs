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
    public class AuthorizationManagementService : IAuthorizationManagementService
    {
        private readonly IAuthorizationRepository _authorizationRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public AuthorizationManagementService(IAuthorizationRepository authorizationRepository, IUserRepository userRepository, IMapper mapper)
        {
            _authorizationRepository = authorizationRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserTypeDto>> GetAllUserTypesAsync()
        {
            var userTypes = await _authorizationRepository.GetAllUserTypesAsync();
            return _mapper.Map<List<UserTypeDto>>(userTypes);
        }

        public async Task<UserTypeDto> AddUserTypeAsync(UserTypeCreateDto userTypeCreateDto) 
        {
            var storedUserType = await _authorizationRepository.GetUserTypeByName(userTypeCreateDto.Name);

            if (storedUserType is not null)
            {
                throw new BadHttpRequestException("User type already exists.");
            }

            var newUserType = _mapper.Map<UserType>(userTypeCreateDto);
            var createdUserType = await _authorizationRepository.AddUserTypeAsync(newUserType);

            return _mapper.Map<UserTypeDto>(createdUserType);
        }

        public async Task<UserTypeDto> UpdateUserTypeAsync(UserTypeDto userTypeUpdateDto)
        {
            var storedUserType = await _authorizationRepository.GetUserTypeById(userTypeUpdateDto.Id);

            if (storedUserType is null)
            {
                throw new BadHttpRequestException("User type doesn't exists.");
            }

            _mapper.Map(userTypeUpdateDto, storedUserType);
            var updatedUserType = await _authorizationRepository.UpdateUserTypeAsync(storedUserType);

            return _mapper.Map<UserTypeDto>(updatedUserType);
        }

        public async Task<UserGetDto> AssignUserTypeAsync(AssignTypeDto assignTypeDto)
        {
            var user = await _userRepository.GetUserByIdAsync(assignTypeDto.UserId);
            user.UserTypeId = assignTypeDto.UserTypeId;

            var updatedUser = await _authorizationRepository.AssignUserTypeAsync(user);

            return _mapper.Map<UserGetDto>(updatedUser);
        }
    }
}
