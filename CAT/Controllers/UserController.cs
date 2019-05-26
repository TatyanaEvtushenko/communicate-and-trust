using System.Collections.Generic;
using CAT.BusinessLayer.Models.UserModels.ViewModels;
using CAT.BusinessLayer.Services.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace CAT.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("top10")]
        public IEnumerable<UserListingViewModel> TopTenUsers(string currentUserName)
        {
            return userService.GetTopUsersCollection(currentUserName);
        }

        [HttpGet("usersSearch")]
        public IEnumerable<UserListingViewModel> UsersSearch(string currentUserName, string searchString)
        {
            return userService.GetUsersCollectionByString(currentUserName, searchString);
        }
    }
}