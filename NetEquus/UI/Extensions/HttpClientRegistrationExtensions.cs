namespace UI.Extensions
{
    public static class HttpClientRegistrationExtensions
    {
        public static IServiceCollection AddApiClientWithCookies<TClient>(this IServiceCollection services, string baseAddress)
            where TClient : class
        {
            services.AddHttpClient<TClient>(client =>
            {
                client.BaseAddress = new Uri(baseAddress);
            })
            .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
            {
                UseCookies = true,
                CookieContainer = SharedCookieContainer.Container
            });

            return services;
        }
    }
}