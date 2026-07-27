using Shared.Dtos.BoardingDtos;
using Shared.Dtos.WrapperDto;

namespace UI.API.Clients
{
    public class HorseTraderClient
    {
        private readonly HttpClient _httpClient;

        public HorseTraderClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> BuyHorseAsync(Guid horseId)
        {
            var response = await _httpClient.PatchAsJsonAsync($"api/Transaction/buy-horse/{horseId}", horseId);
            return response;

        }

        public async Task<HttpResponseMessage> SellHorseAsync(Guid horseId)
        {
            var response = await _httpClient.PatchAsJsonAsync($"api/Transaction/sell-horse/{horseId}", horseId);

            return response;

        }

        public async Task<List<BoardingDto>> GetHorseBoardingHorseTrader ()
        {
            return await _httpClient.GetFromJsonAsync<List<BoardingDto>>("api/HorseTraderData/get-horses-horsetrader")
            ?? new List<BoardingDto> ();
        }
    }
}
