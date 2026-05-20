
using Microsoft.AspNetCore.Http.HttpResults;
using Shared.Dtos.FolaingDtos;

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
    }
}
