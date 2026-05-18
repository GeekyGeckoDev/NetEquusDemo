using Shared.Dtos.BreedDtos;
using Shared.Dtos.NpcDtos;
using System.Security.Cryptography.X509Certificates;

namespace UI.API.Clients
{
    public class NpcClient
    {
        private readonly HttpClient _httpClient;

        public NpcClient(HttpClient httpClient)
        { 
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreateNpcAsync (CreateNpcDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Npc/createnpc", dto);

            Console.WriteLine($"CALLED URL: {response.RequestMessage?.RequestUri}");
            Console.WriteLine($"STATUS: {response.StatusCode}");

            return response;
        }

        public async Task<List<NpcDto>> GetNpcsWithoutEstatesAsync ()
        {
            return await _httpClient.GetFromJsonAsync<List<NpcDto>>("api/Npc/getnpcswithoutestates")
                ?? new List<NpcDto> ();
        }

        public async Task<List<NpcDto>> GetNpcsWithEstatesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<NpcDto>>("api/Npc/getnpcswithestates")
                ?? new List<NpcDto>();
        }
    }
}



//public async Task<List<BreedInfoDto>> GetALlBreedsAsync()
//{
//    return await _httpClient.GetFromJsonAsync<List<BreedInfoDto>>("api/Breed/breedslist")
//        ?? new List<BreedInfoDto>();
//}