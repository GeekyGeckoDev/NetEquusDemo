
using Domain.DomainRules;
using Shared.Dtos.Responses;
using Shared.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserApp.IUserServices
{
    public interface IUserManagerService
    {
        Task<RegistrationResultDto> RegisterUserAsync(UserRegistrationDto userRegistrationDto);
    }
}
