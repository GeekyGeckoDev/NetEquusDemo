using Shared.Dtos.UserDtos;
using System.Security.Claims;

namespace UI.Auth
{
    public class AuthService
    {
        public event Action<ClaimsPrincipal>? UserChanged;

        private ClaimsPrincipal _currentUser = new ClaimsPrincipal(new ClaimsIdentity());

        public ClaimsPrincipal CurrentUser => _currentUser;

        public bool IsLoggedIn => _currentUser.Identity?.IsAuthenticated ?? false;

        public void SetUser(UserMeDto userInfo)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userInfo.Username ?? ""),
                new Claim(ClaimTypes.NameIdentifier, userInfo.UserId.ToString()),
                new Claim(ClaimTypes.Email, userInfo.Email ?? "")
            };

            if (userInfo.IsAdmin)
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));

            _currentUser = new ClaimsPrincipal(new ClaimsIdentity(claims, "cookieAuth"));

            UserChanged?.Invoke(_currentUser);
        }

        public void Logout()
        {
            _currentUser = new ClaimsPrincipal(new ClaimsIdentity());
            UserChanged?.Invoke(_currentUser);
        }
    }
}