using Shared.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UserSessionApp
{
    public interface IUserSessionService
    {
        Task<UserMeDto?> BuildUserSessionAsync(Guid userId);
    }
}
