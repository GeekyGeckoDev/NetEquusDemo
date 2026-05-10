using Domain.DomainRules;
using Shared.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UserApp.IUserServices.IUserValidationServices
{
    public interface IValidationManagerService
    {
        Task<RuleResult> FinalValidationAsync(UserRegistrationDto userRegistrationDto);
    }
}
