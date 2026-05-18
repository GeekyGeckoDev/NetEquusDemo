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
    }
}


