using System.Threading.Tasks;
using CAT.BusinessLayer.Services.AccountServices.Interfaces;
using CAT.BusinessLayer.ViewModels.Account;
using CAT.DataLayer.Models;
using CAT.DataLayer.Models.Enums;
using Microsoft.AspNetCore.Identity;

namespace CAT.BusinessLayer.Services.AccountServices
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AccountService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<IdentityResult> RegisterUser(RegisterAccountViewModel userInfo)
        {
            var user = new User
            {
                Email = userInfo.Email,
                UserName = userInfo.UserName,
                FirstName = userInfo.FirstName,
                SecondName = userInfo.SecondName,
                AvailabilityStatus = UserAvailabilityStatus.Offline
            };
            var result = await userManager.CreateAsync(user, userInfo.Password);
            if (!result.Succeeded)
            {
                return result;
            }
            result = await userManager.AddToRoleAsync(user, "User");
            return result;
        }
    }
}