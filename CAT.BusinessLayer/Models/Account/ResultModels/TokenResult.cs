using System.Collections.Generic;
using CAT.DataLayer.Models;
using Microsoft.AspNetCore.Identity;

namespace CAT.BusinessLayer.Models.Account.ResultModels
{
    public class TokenResult
    {
        public string AccessToken { get; set; }

        public string UserName { get; set; }

        public string Role { get; set; }

        public bool Succeeded { get; set; }

        public IEnumerable<IdentityError> Errors { get; set; }

        public TokenResult(User user, string role = null, string accessToken = null)
        {
            Succeeded = user != null;
            if (!Succeeded)
            {
                Errors = new[]
                {
                    new IdentityError {Code = "400", Description = "Invalid username or password."}
                };
            }
            else
            {
                UserName = user?.UserName;
                Role = role;
                AccessToken = accessToken;
            }
        }
    }
}
