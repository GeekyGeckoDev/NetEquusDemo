using Shared.Dtos.HorseDtos;

namespace UI.API.Clients
{
    public class HorseCarouselClient
    {
        private readonly HttpClient _httpClient;

        public HorseCarouselClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<HorseInfoDto>> GetRandomHorsesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<HorseInfoDto>>("api/HorseCarousel/get-random-horses")

                ?? new List<HorseInfoDto>();
        }
    }
}
