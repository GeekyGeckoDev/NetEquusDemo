using Shared.Dtos.CompetitionDtos;

namespace UI.API.Clients
{
    public class CompetitionClient
    {
        private readonly HttpClient _httpClient;

        public CompetitionClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreateCompetitionAsync(CreateCompetitionDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync(
                "api/Competition/createCompetition",
                dto);
            return response;
        }

        public async Task<List<CompetitionDto>> GetAllCompetitionsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<CompetitionDto>>(
                "api/Competition/competitionList")
                ?? new List<CompetitionDto>();
        }
    }
}
