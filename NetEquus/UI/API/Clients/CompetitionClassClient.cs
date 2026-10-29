using Shared.Dtos.CompetitionDtos;
using Shared.Dtos.CompetitionDtos.CompDisciplineDtos;

namespace UI.API.Clients
{
    public class CompetitionClassClient
    {
        private readonly HttpClient _httpClient;

        public CompetitionClassClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreateCompetitionDisciplineClassAsync(CreateCompetitionDisciplineWithClassDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync(
        "api/CompetitionDisciplineClass/competitiondisciplinesclass",
        dto);

            return response;
        }

        public async Task<List<CompetitionClassDto>> GetAllCompetitionClassesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<CompetitionClassDto>>(
                "api/CompetitionClass/competitionClassList")
                ?? new List<CompetitionClassDto>();
        }
    }
}
