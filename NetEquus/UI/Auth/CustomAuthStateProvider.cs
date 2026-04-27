using Microsoft.AspNetCore.Components.Authorization;


namespace UI.Auth
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly AuthService _authService;

        public CustomAuthStateProvider(AuthService authService)
        {
            _authService = authService;

            _authService.UserChanged += (user) =>
            {
                NotifyAuthenticationStateChanged(
                    Task.FromResult(new AuthenticationState(user))
                );
            };
        }

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            return Task.FromResult(new AuthenticationState(_authService.CurrentUser));
        }
    }
}