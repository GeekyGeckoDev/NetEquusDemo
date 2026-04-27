using Application.AuthApp.AuthMessages;
using Application.AuthApp.IAuthServices;
using Application.UserApp.IUserServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos;
using Shared.Dtos.UserDtos;
using System.Security.Claims;

namespace APIAuthentication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogInService _logInService;
        private readonly IJWTService _jWTService;

        private CookieOptions BuildCookieOptions(DateTime expires)
        {
            return new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = expires
            };
        }


        public AuthController(ILogInService logInService, IJWTService jWTService)
        {
            _logInService = logInService;
            _jWTService = jWTService;
       
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var tokens = await _logInService.ValidateUserAsync(dto);

            Response.Cookies.Append("accessToken", tokens.AccessToken, BuildCookieOptions(DateTime.UtcNow.AddMinutes(15)));
            Response.Cookies.Append("refreshToken", tokens.RefreshToken, BuildCookieOptions(DateTime.UtcNow.AddDays(7)));

            return Ok(new { message = "Login successful" });
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> Refresh()
        {
            var refreshToken = Request.Cookies["refreshToken"];

            var tokens = await _logInService.RefreshAsync(refreshToken);

            if (tokens == null)
                return Unauthorized();

            Response.Cookies.Append("accessToken", tokens.AccessToken, BuildCookieOptions(DateTime.UtcNow.AddMinutes(15)));
            Response.Cookies.Append("refreshToken", tokens.RefreshToken, BuildCookieOptions(DateTime.UtcNow.AddDays(7)));

            return Ok();
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("accessToken");
            Response.Cookies.Delete("refreshToken");

            return Ok();
        }

        [HttpGet("me")]
        public IActionResult Me()
        {
            return Ok(new
            {
                isAuth = User.Identity?.IsAuthenticated,
                name = User.Identity?.Name,
                claims = User.Claims.Select(c => new { c.Type, c.Value })
            });
        }

    }
}
