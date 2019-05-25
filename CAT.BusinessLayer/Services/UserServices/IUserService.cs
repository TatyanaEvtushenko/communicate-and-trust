using System.Collections.Generic;
using CAT.BusinessLayer.Models.UserModels.ViewModels;
using CAT.DataLayer.Models;

namespace CAT.BusinessLayer.Services.UserServices
{
    public interface IUserService
    {
        IEnumerable<UserListingViewModel> GetTopUsersCollection();

        IEnumerable<UserListingViewModel> GetUsersCollectionByString(string searchString);

        string GetUserIdByName(string name);

        User GetUserByName(string name);
    }
}
