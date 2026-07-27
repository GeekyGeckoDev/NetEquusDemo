
using Microsoft.AspNetCore.Http.HttpResults;
using Shared.Dtos.FolaingDtos;
using Shared.Dtos.HorseDtos;

namespace UI.API.Clients
{
    public class FoalingClient
    {
        private readonly HttpClient _httpClient;

        public FoalingClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreateFoalingAsync(CreateFoalingDto dto)
        {
            Console.WriteLine(_httpClient.BaseAddress);

            Console.WriteLine(
    $"api/Foaling/create-foaling");

            return await _httpClient.PostAsJsonAsync(
            "api/Foaling/create-foaling",
            dto);


        }

        public async Task<List<HorseInfoDto>> GetEligibleMaresAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<HorseInfoDto>>("api/Foaling/get-eligible-mares")

          ?? new List<HorseInfoDto>();
        }

         public async Task<List<HorseInfoDto>> GetEligibleStallionsAsync(Guid damId)
        {
            return await _httpClient.GetFromJsonAsync<List<HorseInfoDto>>($"api/Foaling/get-eligible-stallions/{damId}")

            ?? new List<HorseInfoDto>();

        }
    }
}
