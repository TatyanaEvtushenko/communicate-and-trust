using System.Threading.Tasks;
using CAT.BusinessLayer.Models.Account.ResultModels;
using CAT.BusinessLayer.Models.Account.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace CAT.BusinessLayer.Services.AccountServices.Interfaces
{
    public interface IAccountService
    {
        Task<IdentityResult> RegisterUser(RegisterAccountViewModel userInfo);

        Task<TokenResult> GetAccessToken(LoginAccountViewModel userInfo);

        Task SignOut();
    }
}
