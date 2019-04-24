using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace CAT.BusinessLayer.Utils.Tokens
{
    public static class TokenGenerator
    {
        public static string GenerateSecurityToken(ClaimsIdentity identity)
        {
            var jwt = CreateToken(identity);
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return encodedJwt;
        }

        private static JwtSecurityToken CreateToken(ClaimsIdentity identity)
        {
            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.Issuer,
                audience: AuthOptions.Audience,
                notBefore: now,
                claims: identity.Claims,
                expires: now.Add(TimeSpan.FromMinutes(AuthOptions.Lifetime)),
                signingCredentials: CreateSigningCredentials());
            return jwt;
        }

        private static SigningCredentials CreateSigningCredentials()
        {
            var securityKey = AuthOptions.GetSymmetricSecurityKey();
            var signingCred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            return signingCred;
        }
    }
}
