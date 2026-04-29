using Application.EstateApp.EstateDtos;
using Shared.Dtos.UserDtos;
using Shared.Dtos.WrapperDto;

namespace UI.API.Clients
{
    public class EstateClient
    {
        private readonly HttpClient _httpClient;

        public EstateClient(HttpClient httpClient)
        { 
            _httpClient = httpClient;

        }

        public async Task<HttpResponseMessage> CreateEstateAsync(CreateEstateRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Estate/estatecreation", request);

            Console.WriteLine($"CALLED URL: {response.RequestMessage?.RequestUri}");
            Console.WriteLine($"STATUS: {response.StatusCode}");

            return response;

        }
    }
}
