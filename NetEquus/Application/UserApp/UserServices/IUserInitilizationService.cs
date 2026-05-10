using Shared.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UserApp.UserServices
{
    public interface IUserInitilizationService
    {
        Task UserInitilizationAsync(UserRegistrationDto dto);
    }
}
