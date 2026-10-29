using Shared.Dtos.CompetitionDtos;

namespace UI.API.Clients
{
    public class CompetitionEntryClient
    {
        private readonly HttpClient _httpClient;

       public CompetitionEntryClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreateCompetitionEntryAsync(CreateCompetitionEntryDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync(
                "api/CompetitionEntry/createCompetitionEntry",
                dto);
            return response;
        }
    }
}
