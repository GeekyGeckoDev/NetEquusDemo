
namespace UI.API.Clients
{
    public class ArtistClient
    {
        private readonly HttpClient _httpClient;

        public ArtistClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> ApplyForArtistAsync()
        {
            return await _httpClient.PostAsync(
                "api/Artist/artistcreation",
                null);
        }

    }
}
