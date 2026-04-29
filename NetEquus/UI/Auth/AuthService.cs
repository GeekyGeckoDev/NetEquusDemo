using Domain.Entities.Models.Users;
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

        public Guid UserId { get; private set; }
        public string? Username { get; private set; }
        public string? Email { get; private set; }
        public bool IsAdmin { get; private set; }

        public Guid? EstateId { get; private set; }
        public string? EstateName { get; private set; }

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

            // store easy-access session info
            UserId = userInfo.UserId;
            Username = userInfo.Username;
            Email = userInfo.Email;
            IsAdmin = userInfo.IsAdmin;

            EstateId = userInfo.EstateId;
            EstateName = userInfo.EstateName;

            UserChanged?.Invoke(_currentUser);
        }

        public void Logout()
        {
            _currentUser = new ClaimsPrincipal(new ClaimsIdentity());

            UserId = Guid.Empty;
            Username = null;
            Email = null;
            IsAdmin = false;
            EstateId = null;
            EstateName = null;

            UserChanged?.Invoke(_currentUser);
        }



  
    }
}