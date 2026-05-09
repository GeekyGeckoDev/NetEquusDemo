using Shared.Dtos.HorseArtistDtos;

namespace UI.API.Clients
{
    public class AdminArtistClient 
    {
        private readonly HttpClient _httpClient;

        public AdminArtistClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<HorseArtistDto>> GetPendingArtistsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<HorseArtistDto>>(
                "api/AdminArtist/pending")
                ?? new List<HorseArtistDto>();
        }

        public async Task<HttpResponseMessage> ApproveArtistAsync(Guid userId)
        {
            var response = await _httpClient.PatchAsync(
                $"api/AdminArtist/approve/{userId}",
                null);

            Console.WriteLine(response.StatusCode);
            Console.WriteLine(await response.Content.ReadAsStringAsync());

            return response;
        }
    }
}
