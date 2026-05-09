using Microsoft.AspNetCore.Components.Authorization;


namespace UI.Auth
{
    using Microsoft.AspNetCore.Components.Authorization;
    using System.Security.Claims;

    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly AuthService _authService;

        public CustomAuthStateProvider(AuthService authService)
        {
            _authService = authService;
            _authService.UserChanged += Notify;
        }

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            return Task.FromResult(
                new AuthenticationState(_authService.CurrentUser));
        }

        private void Notify(ClaimsPrincipal user)
        {
            NotifyAuthenticationStateChanged(
                Task.FromResult(new AuthenticationState(user)));
        }
    }
}