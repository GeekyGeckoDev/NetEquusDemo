using Application.UserApp.IUserServices.IUserCrudServices;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.UserApp.IUserServices;
using Shared.Mappers.UserMapper;
using Shared.Dtos.UserDtos;
using Domain.Entities.Models.Users;
using Application.AuthApp.Exceptions;
using Application.AuthApp.IAuthServices;
using Shared.Dtos.Responses;

namespace Application.AuthApp.AuthServices
{
    public class LogInService : ILogInService
    {
        private readonly IUserGetService _userGetService;

        private readonly IPasswordHasherService _passwordHasherService;

        private readonly IJWTService _jWTService;

        public LogInService(IUserGetService userGetService, IPasswordHasherService passwordHasherService, IJWTService jWTService)
        {
            _userGetService = userGetService;
            _passwordHasherService = passwordHasherService;
            _jWTService = jWTService;
        }

        public async Task<TokenResponseDto> ValidateUserAsync(LoginDto loginDto)
        {

            var user = await _userGetService.GetUserByEmailAsync(loginDto.Email);

            if (user == null || !_passwordHasherService.VerifyPassword(loginDto.Password, user.Password_Hash))
            {
                throw new LoginException();
            }

            return await _jWTService.CreateUserTokenResponse(user);
       
        }

        public async Task<TokenResponseDto?> RefreshAsync(string refreshToken)
        {
            var user = await _userGetService.GetUserByRefreshTokenAsync(refreshToken);

            if (user == null ||
                user.RefreshToken != refreshToken ||
                user.RefreshTokenExpiryTime <= DateTime.UtcNow)
            {
                return null;
            }

            return await _jWTService.CreateUserTokenResponse(user);
        }
    }
}
