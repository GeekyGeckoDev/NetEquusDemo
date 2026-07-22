using Domain.Entities.Models.Users;
using Shared.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UserApp.UserServices
{
    public class UserInitilizationService : IUserInitilizationService
    {
        public async Task UserInitilizationAsync (UserRegistrationDto dto)
        {
            var user = new User
            {
                IsNpc = false,
                UserType = 0,
                CanLogin = true
            };
        }
    }
}
