using Shared.Dtos.WrapperDto;

namespace UI.API.Clients
{
    public class BreedGenStatsClient
    {
        private readonly HttpClient _httpClient;

        public BreedGenStatsClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> UpdateBreedGenProfileAsync (BreedGenerationProfileDto dto)
        {
            var response = await _httpClient.PatchAsJsonAsync($"api/BreedStats/updateGenStats/{dto.BreedId}", dto);

            Console.WriteLine($"CALLED URL: {response.RequestMessage?.RequestUri}");
            Console.WriteLine($"STATUS: {response.StatusCode}");

            return response;

        }
    }
}
