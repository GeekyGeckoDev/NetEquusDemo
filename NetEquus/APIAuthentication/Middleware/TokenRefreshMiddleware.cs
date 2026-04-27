using Application.UserApp.IUserServices;
using System.IdentityModel.Tokens.Jwt;

namespace APIAuthentication.Middleware
{
    public class TokenRefreshMiddleware
    {
        private readonly RequestDelegate _next;

        public TokenRefreshMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ILogInService loginService)
        {
            var accessToken = context.Request.Cookies["accessToken"];

            if (IsExpired(accessToken))
            {
                var refreshToken = context.Request.Cookies["refreshToken"];
                var tokens = await loginService.RefreshAsync(refreshToken);

                if (tokens != null)
                {
                    context.Response.Cookies.Append("accessToken", tokens.AccessToken);
                    context.Response.Cookies.Append("refreshToken", tokens.RefreshToken);
                }
            }

            await _next(context);
        }

        private bool IsExpired(string? token)
        {
            if (string.IsNullOrEmpty(token))
                return true;

            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(token);

            return jwt.ValidTo < DateTime.UtcNow;
        }
    }
}
