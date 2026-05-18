
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

        public async Task<List<BoardingDto>> GetNpcBoardingAsync (Guid estateId)
        {
            return await _httpClient.GetFromJsonAsync<List<BoardingDto>>($"api/Boarding/get-npc-horseboardings/{estateId}")
            ?? new List<BoardingDto> ();
        }

        public async Task<HttpResponseMessage> UpdateHorseBoardingOwnershipAsync (TransferHorseDto dto)
        {
            var response = await _httpClient.PatchAsJsonAsync($"api/Relations/update/{dto.HorseId},{dto.NewEstateId}", dto);

            return response;
        }
    }
}
