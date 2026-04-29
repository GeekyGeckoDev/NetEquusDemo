using System.Threading.Tasks;

namespace UI.Extensions
{

    public class TokenStore : ITokenStore
    {
        private readonly Guid _instanceId = Guid.NewGuid();
        private string? _token;

        public Task SetAsync(string token)
        {
            _token = token;
            Console.WriteLine($"[{_instanceId}] TOKEN STORED: {_token}");
            return Task.CompletedTask;
        }

        public Task<string?> GetAsync()
        {
            Console.WriteLine($"[{_instanceId}] TOKEN FETCHED: {_token}");
            return Task.FromResult(_token);
        }
    }
}