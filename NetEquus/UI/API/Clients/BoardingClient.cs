
using Application.EstateApp.EstateDtos;
using Shared.Dtos.BoardingDtos;
using Shared.Dtos.HorseDtos;

namespace UI.API.Clients
{
    public class BoardingClient
    {
        private readonly HttpClient _httpClient;

        public BoardingClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<BoardingDto>> GetBoardingByEstateIdAsync (Guid estateId)
        {
            return await _httpClient.GetFromJsonAsync<List<BoardingDto>>($"api/Boarding/get-horseboardings/{estateId}")
            ?? new List<BoardingDto> ();
        }

        public async Task<HttpResponseMessage> UpdateHorseBoardingOwnershipAsync (TransferHorseDto dto)
        {
            var response = await _httpClient.PatchAsJsonAsync($"api/Relations/update/{dto.HorseId},{dto.NewEstateId}", dto);

            return response;
        }

        public async Task<List<BoardingDto>> SearchBoardingsAsync (Guid estateId, string? search, int? sex)
        {
            return await _httpClient.GetFromJsonAsync<List<BoardingDto>>($"api/Boarding/search-boardings?" +
                $"estateId={estateId}" +
                $"&search={search} +" +
                $"&sex={sex}")

            ?? new();
        }
    }
}
