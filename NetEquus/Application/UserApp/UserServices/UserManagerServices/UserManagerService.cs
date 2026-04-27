using Application.AuthApp.IAuthServices;
using Application.UserApp.IUserServices;
using Application.UserApp.IUserServices.IUserValidationServices;
using Domain.DomainRules;
using Shared.Dtos.Responses;
using Shared.Dtos.UserDtos;
using Shared.Mappers.UserMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserApp.UserSevices.UserManagerServices
{
    public class UserManagerService : IUserManagerService
    {
        private readonly IUserCrudService _userCrudService;

        private readonly IPasswordHasherService _passwordHasherService;

        private readonly IRegistrationValidationService _registrationValidationService;

        private readonly IPasswordValidationService _passwordValidationService;


        public UserManagerService(IUserCrudService userCrudService, IPasswordHasherService passwordHasherService, IRegistrationValidationService registrationValidationService, IPasswordValidationService passwordValidationService)
        {
            _userCrudService = userCrudService;
            _passwordHasherService = passwordHasherService;
            _registrationValidationService = registrationValidationService;
            _passwordValidationService = passwordValidationService;
        }

        public async Task<RegistrationResultDto> RegisterUserAsync(UserRegistrationDto userRegistrationDto)
        {
            var usernameCheck = await _registrationValidationService.CheckUsernameAsync(userRegistrationDto);
            if (usernameCheck == null || !usernameCheck.IsAllowed)
                return new RegistrationResultDto
                {
                    IsAllowed = false,
                    Message = usernameCheck?.Message ?? "Username invalid"
                };

            var passwordCheck = await _passwordValidationService.CheckPasswordAsync(userRegistrationDto.Password);
            if (!passwordCheck.IsAllowed)
                return new RegistrationResultDto
                {
                    IsAllowed = false,
                    Message = passwordCheck.Message
                };

            var user = UserMapper.ToNewUser(userRegistrationDto);
            user.Password_Hash = _passwordHasherService.HashPassword(userRegistrationDto.Password);

            var userId = await _userCrudService.CreateUserAsync(user);

            return new RegistrationResultDto
            {
                IsAllowed = true,
                Message = "User created successfully",
                UserId = userId
            };
        }
    }
}
