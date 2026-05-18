using Shared.Dtos.OwnershipDtos;

namespace UI.API.Clients
{
    public class EstateOwnershipClient
    {
        private readonly HttpClient _httpClient;

        public EstateOwnershipClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<EstateOwnershipDto?> GetEstateOwnershipsByUserId(Guid userId)
        {
            var response = await _httpClient.GetAsync(
                $"api/Estate/get-estate-ownership-by-userid/{userId}");

            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                return null;

            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<EstateOwnershipDto>();
        }
    }
}
