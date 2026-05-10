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

        public async Task<List<BreedInfoDto>> GetALlBreedsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<BreedInfoDto>>("api/Breed/breedslist")
                ?? new List<BreedInfoDto>();
        }

        public async Task<HttpResponseMessage> UpdateBreedAsync(BreedInfoDto dto)
        {
            var response = await _httpClient.PatchAsJsonAsync(
                $"api/Breed/update/{dto.BreedId}",
                dto);

            return response;
        }
    }
}
