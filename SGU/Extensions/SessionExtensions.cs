// SessionExtensions.cs
using Microsoft.AspNetCore.Http;

namespace Microsoft.AspNetCore.Http
{
    public static class SessionExtensions
    {
        public static bool GetBool(this ISession session, string key)
        {
            var value = session.GetString(key);
            return !string.IsNullOrEmpty(value) && bool.TryParse(value, out var result) ? result : false;
        }

        public static void SetBool(this ISession session, string key, bool value)
        {
            session.SetString(key, value.ToString());
        }
    }
}
