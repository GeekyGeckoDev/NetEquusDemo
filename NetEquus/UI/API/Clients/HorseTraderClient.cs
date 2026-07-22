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

        public async Task<HttpResponseMessage> SellHorseAsync (HorseTraderRequest request)
        {
            var response = await _httpClient.PatchAsJsonAsync("api/Transaction/horse-sale", request);
            return response;
        }
    }
}
