using Shared.Dtos.UserDtos;

namespace UI.API.Clients
{
    public class RegisterClient
    {
        private readonly HttpClient _httpClient;

        public RegisterClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> RegisterAsync(UserRegistrationDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/UserRegistration/register", dto);

            Console.WriteLine($"CALLED URL: {response.RequestMessage?.RequestUri}");
            Console.WriteLine($"STATUS: {response.StatusCode}");

            return response;
        }


    }
}
