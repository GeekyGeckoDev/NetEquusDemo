using Shared.Dtos.Responses;
using Shared.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserApp.IUserServices
{
    public interface ILogInService
    {
        Task<TokenResponseDto> ValidateUserAsync(LoginDto loginDto);

        Task<TokenResponseDto?> RefreshAsync(string refreshToken);
    }
}
