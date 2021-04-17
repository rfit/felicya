using System.Text;
using Microsoft.AspNetCore.Http;

namespace FelicyaClient.Helpers
{
    internal static class SessionExtensions
    {
        public static bool TryGetString(this ISession session, string key, out string value)
        {
            value = null;
            if (!session.TryGetValue(key, out var bytes))
                return false;

            value = Encoding.UTF8.GetString(bytes);
            return true;
        }
    }
}