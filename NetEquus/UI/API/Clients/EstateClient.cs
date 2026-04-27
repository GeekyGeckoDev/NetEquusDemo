using Application.EstateApp.EstateDtos;
using Shared.Dtos.UserDtos;

namespace UI.API.Clients
{
    public class EstateClient
    {
        private readonly HttpClient _httpClient;

        public EstateClient(HttpClient httpClient)
        { 
            _httpClient = httpClient;

        }

        public async Task<HttpResponseMessage> CreateEstateAsync(EstateCreationDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Estate/estatecreation", dto);

            Console.WriteLine($"CALLED URL: {response.RequestMessage?.RequestUri}");
            Console.WriteLine($"STATUS: {response.StatusCode}");

            return response;

        }
    }
}
