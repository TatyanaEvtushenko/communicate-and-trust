using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CAT.BusinessLayer.Models.Account.ResultModels;
using CAT.BusinessLayer.Models.Account.ViewModels;
using CAT.BusinessLayer.Services.AccountServices.Interfaces;
using CAT.BusinessLayer.Services.ImageStoreServices;
using CAT.BusinessLayer.Utils.Tokens;
using CAT.DataLayer.Models;
using CAT.DataLayer.Models.Enums;
using CAT.DataLayer.Repositories.DatabaseRepositories.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace CAT.BusinessLayer.Services.AccountServices
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IDatabaseRepository<User> userRepository;
        private readonly IImageStoreService imageStoreService;

        public AccountService(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IDatabaseRepository<User> userRepository,
            IImageStoreService imageStoreService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.userRepository = userRepository;
            this.imageStoreService = imageStoreService;
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
            if (userInfo.File != null)
            {
                user.AvatarUrl = imageStoreService.Save(
                    userInfo.File.FileName,
                    userInfo.File.OpenReadStream());
            }

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

            UpdateUserStatus(user, UserAvailabilityStatus.Online);
            var userRole = await GetFirstUserRole(user);
            var identity = GetIdentity(user, userRole);
            var token = TokenGenerator.GenerateSecurityToken(identity);
            return new TokenResult(user, userRole, token);
        }

        public async Task SignOut()
        {
            var claims = signInManager.Context.User;
            var user = userRepository.GetFirst(x => x.UserName == claims.Identity.Name);
            UpdateUserStatus(user, UserAvailabilityStatus.Offline);
            await signInManager.SignOutAsync();
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

        private void UpdateUserStatus(User user, UserAvailabilityStatus status)
        {
            user.AvailabilityStatus = status;
            userRepository.Update(user);
        }
    }
}