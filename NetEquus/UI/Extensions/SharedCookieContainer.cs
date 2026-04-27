using System.Net;

namespace UI.Extensions
{
    public static class SharedCookieContainer
    {
        public static CookieContainer Container { get; } = new CookieContainer();
    }
}
