namespace UI.API.Clients
{
    public class HorseArtistClient
    {
        private readonly HttpClient _httpClient;

        public HorseArtistClient(HttpClient httpClient)
        {
            _httpClient = httpClient;

        }
    }
}
