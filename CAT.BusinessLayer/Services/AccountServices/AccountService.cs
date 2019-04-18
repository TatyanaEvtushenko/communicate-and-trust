using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CAT.BusinessLayer.Models.Account.ResultModels;
using CAT.BusinessLayer.Models.Account.ViewModels;
using CAT.BusinessLayer.Services.AccountServices.Interfaces;
using CAT.BusinessLayer.Utils.Tokens;
using CAT.BusinessLayer.ViewModels.Account;
using CAT.DataLayer.Models;
using CAT.DataLayer.Models.Enums;
using CAT.DataLayer.Repositories.BaseRepositories.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace CAT.BusinessLayer.Services.AccountServices
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IDatabaseRepository<User> userRepository;

        public AccountService(UserManager<User> userManager, SignInManager<User> signInManager,
            IDatabaseRepository<User> userRepository)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.userRepository = userRepository;
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

        public async Task<TokenResult> GetAccessToken(LoginAccountViewModel userInfo)
        {
            var user = await GetUserByUserNameOrEmail(userInfo);
            if (user == null)
            {
                return new TokenResult(null);
            }
            user.AvailabilityStatus = UserAvailabilityStatus.Online;
            userRepository.Update(user);
            var userRole = await GetFirstUserRole(user);
            var identity = GetIdentity(user, userRole);
            var token = TokenGenerator.GenerateSecurityToken(identity);
            return new TokenResult(user, userRole, token);
        }

        private async Task<User> GetUserByUserNameOrEmail(LoginAccountViewModel userInfo)
        {
            var user = await userManager.FindByEmailAsync(userInfo.Login);
            return user ?? await userManager.FindByNameAsync(userInfo.Login);
        }

        private async Task<string> GetFirstUserRole(User user)
        {
            var userRoles = await userManager.GetRolesAsync(user);
            return userRoles.FirstOrDefault();
        }

        private ClaimsIdentity GetIdentity(User user, string userRole)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, userRole)
            };
            var claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
        }
    }
}