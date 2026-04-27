using Shared.Dtos.UserDtos;
using System.Text.Json;
using UI.API.ApiClients;

namespace UI.Auth
{
    public class AuthManager
    {
        private readonly AuthClient _authClient;
        private readonly AuthService _authService;

        public AuthManager(AuthClient authClient, AuthService authService)
        {
            _authClient = authClient;
            _authService = authService;
        }

        public async Task<bool> LoginAsync(LoginDto dto)
        {
            var loginResponse = await _authClient.LoginAsync(dto);

            if (!loginResponse.IsSuccessStatusCode)
                return false;

            return await RefreshUserFromApi();
        }

        public async Task<bool> RefreshUserFromApi()
        {
            var meResponse = await _authClient.MeAsync();

            if (!meResponse.IsSuccessStatusCode)
            {
                _authService.Logout();
                return false;
            }

            var json = await meResponse.Content.ReadAsStringAsync();

            var userInfo = JsonSerializer.Deserialize<UserMeDto>(
                json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (userInfo == null)
            {
                _authService.Logout();
                return false;
            }

            _authService.SetUser(userInfo);
            return true;
        }

        public async Task LogoutAsync()
        {
            await _authClient.LogoutAsync();
            _authService.Logout();
        }
    }
}