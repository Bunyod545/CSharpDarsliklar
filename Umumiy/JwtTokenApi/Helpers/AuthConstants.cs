using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace JwtTokenApi.Helpers
{
    /// <summary>
    /// Autentifikatisya sozlamalari
    /// </summary>
    public class AuthConstants
    {
        /// <summary>
        /// Maxfiy kalit
        /// </summary>
        public const string Key = "JwtTokenApiSecurityKey";

        /// <summary>
        /// Token beruvchi haqida malumot
        /// </summary>
        public const string ValidIssuer = "ExampleIssuer";

        /// <summary>
        /// Tokendan foydalanuvchi haqida malumot
        /// </summary>
        public const string ValidAudience = "ExampleAudience";

        /// <summary>
        /// Maxfiy kalitni olish
        /// </summary>
        /// <returns></returns>
        public static SymmetricSecurityKey GetSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
        }
    }
}
