using Shared.Dtos.BreedDtos;

namespace UI.API.Clients
{
    public class BreedClient
    {
        private readonly HttpClient _httpClient;

        public BreedClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreateBreedAsync(BreedDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Breed/breedcreation", dto);

            Console.WriteLine($"CALLED URL: {response.RequestMessage?.RequestUri}");
            Console.WriteLine($"STATUS: {response.StatusCode}");

            return response;
        }
    }
}
