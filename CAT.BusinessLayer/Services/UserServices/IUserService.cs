using System.Collections.Generic;
using CAT.BusinessLayer.Models.UserModels.ViewModels;
using CAT.DataLayer.Models;

namespace CAT.BusinessLayer.Services.UserServices
{
    public interface IUserService
    {
        IEnumerable<UserListingViewModel> GetTopUsersCollection(string currentUserName);

        IEnumerable<UserListingViewModel> GetUsersCollectionByString(string currentUserName, string searchString);

        string GetUserIdByName(string name);

        User GetUserByName(string name);
    }
}
