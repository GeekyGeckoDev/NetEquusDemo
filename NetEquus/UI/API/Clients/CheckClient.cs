namespace UI.API.Clients
{
    public class CheckClient
    {
        private readonly HttpClient _httpClient;

        public CheckClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> ProcessDueFoalingsAsync ()
        {
            var response = await _httpClient.PostAsync("api/ProcessFoaling/process-due-foalings", null);

            Console.WriteLine($"CALLED URL: {response.RequestMessage?.RequestUri}");
            Console.WriteLine($"STATUS: {response.StatusCode}");

            return response;
        }
    }
}
