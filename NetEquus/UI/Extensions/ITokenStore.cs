namespace UI.Extensions
{
    public interface ITokenStore
    {
        Task SetAsync(string token);
        Task<string?> GetAsync();
    }
}
