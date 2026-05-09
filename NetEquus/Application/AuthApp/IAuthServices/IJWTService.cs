using Domain.Entities.Models.Users;
using Shared.Dtos;
using Shared.Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.AuthApp.IAuthServices
{
    public interface IJWTService
    {
        Task<TokenResponseDto> CreateUserTokenResponse(User user);

        Task<TokenResponseDto?> RefreshTokensAsync(UserRefreshTokenRequestDto request);

    }
}
