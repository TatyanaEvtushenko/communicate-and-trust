using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CAT.BusinessLayer.Utils.Tokens
{
    public class AuthOptions
    {
        public const string Issuer = "CATAuthServer"; // издатель токена
        public const string Audience = "http://localhost:62001/"; // потребитель токена
        public const int Lifetime = 1; // время жизни токена - 1 минута

        private const string Key = "mysupersecret_secretkey!123";   // ключ для шифрации

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
        }
    }
}
