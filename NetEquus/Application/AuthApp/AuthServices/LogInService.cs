using Application.UserApp.IUserServices.IUserCrudServices;
using Application.UserApp.IUserServices;
using Shared.Dtos.UserDtos;
using Application.AuthApp.Exceptions;
using Application.AuthApp.IAuthServices;
using Shared.Dtos.Responses;
using Application.UnitOfWorks;

namespace Application.AuthApp.AuthServices
{
    public class LogInService : ILogInService
    {
        private readonly IUserGetService _userGetService;

        private readonly IPasswordHasherService _passwordHasherService;

        private readonly IJWTService _jWTService;

        private readonly IUnitOfWork _unitOfWork;


        public LogInService(IUserGetService userGetService, IPasswordHasherService passwordHasherService, IJWTService jWTService, IUnitOfWork unitOfWork)
        {
            _userGetService = userGetService;
            _passwordHasherService = passwordHasherService;
            _jWTService = jWTService;
            _unitOfWork = unitOfWork;
        }

        public async Task<TokenResponseDto> ValidateUserAsync(LoginDto loginDto)
        {

            var user = await _userGetService.GetUserByEmailAsync(loginDto.Email);

            // Failed logins
            if (user == null)
            {
                throw new LoginException("Invalid credentials");
            }

                if (user.LockedUntil.HasValue &&
                user.LockedUntil > DateTime.UtcNow)
                {
                throw new LoginException($"Account locked until{user.LockedUntil.Value:u}");
                }

            var validPassword = _passwordHasherService.VerifyPassword(loginDto.Password, user.Password_Hash);

            if (!validPassword)
            {
                user.FailedLoginCount++;

                if (user.FailedLoginCount >= 5)
                {
                    user.LockedUntil = DateTime.UtcNow.AddMinutes(5);

                    user.FailedLoginCount = 0;
                }


                await _unitOfWork.CommitAsync();

                throw new LoginException("Invalid credentials");

            }



            user.FailedLoginCount = 0;
            user.LockedUntil = null;


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
