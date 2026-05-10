using Application.UserApp.IUserServices.IUserValidationServices;
using Domain.DomainRules;
using Shared.Dtos.Responses;
using Shared.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UserApp.UserServices.UserValidationServices
{
    public class ValidationManagerService : IValidationManagerService
    {

        private readonly IRegistrationValidationService _registrationValidationService;

        private readonly IPasswordValidationService _passwordValidationService;

        public ValidationManagerService(IRegistrationValidationService registrationValidationService, IPasswordValidationService passwordValidationService)
        {
            _registrationValidationService = registrationValidationService;
            _passwordValidationService = passwordValidationService;
        }

        public async Task<RuleResult> FinalValidationAsync (UserRegistrationDto userRegistrationDto)
        {
            var usernameCheck = await _registrationValidationService.CheckUsernameAsync(userRegistrationDto);
            if (usernameCheck == null || !usernameCheck.IsAllowed)
                new RegistrationResultDto
                {
                    IsAllowed = false,
                    Message = usernameCheck?.Message ?? "Username invalid"
                };

            var passwordCheck = await _passwordValidationService.CheckPasswordAsync(userRegistrationDto.Password);
            if (!passwordCheck.IsAllowed)
                new RegistrationResultDto
                {
                    IsAllowed = false,
                    Message = passwordCheck.Message
                };

            return RuleResult.Success();
        }

    }
}
