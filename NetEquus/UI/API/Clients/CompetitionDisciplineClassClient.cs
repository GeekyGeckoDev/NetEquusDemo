using Shared.Dtos.CompetitionDtos;
using Shared.Dtos.CompetitionDtos.CompDisciplineDtos;

namespace UI.API.Clients
{
    public class CompetitionDisciplineClassClient
    {
        private readonly HttpClient _httpClient;

        public CompetitionDisciplineClassClient(HttpClient httpClient)
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

        public async Task<List<Competit>
    }
}
