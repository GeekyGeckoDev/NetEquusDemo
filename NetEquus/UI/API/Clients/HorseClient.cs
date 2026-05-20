using Shared.Dtos.HorseDtos;
using System.Formats.Asn1;

namespace UI.API.Clients
{
    public class HorseClient
    {
        private readonly HttpClient _httpClient;

        public HorseClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> GenerateHorseAsync ()
        {
            var response = await _httpClient.PostAsync("api/Horse/generate-horse", null);

            Console.WriteLine($"CALLED URL: {response.RequestMessage?.RequestUri}");
            Console.WriteLine($"STATUS: {response.StatusCode}");

            return response;
        }

        public async Task<List<HorseInfoDto>> GetAllMaresAsync ()
        {
            return await _httpClient.GetFromJsonAsync<List<HorseInfoDto>>("api/Horse/mares")

                ?? new List<HorseInfoDto>();

        }

        public async Task<List<HorseInfoDto>> GetAllStallionsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<HorseInfoDto>>("api/Horse/stallions")

                ?? new List<HorseInfoDto>();

        }

        public async Task<PedigreeDto> GetPedigree (Guid horseId, int generations)
        {
            var response = await _httpClient.GetAsync($"api/Horse/get-pedigree/{horseId},{generations}");

            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                return null;

            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<PedigreeDto>();
                
        }



    }
}


