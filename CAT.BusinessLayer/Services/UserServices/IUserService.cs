using System.Collections.Generic;
using CAT.BusinessLayer.Models.UserModels.ViewModels;

namespace CAT.BusinessLayer.Services.UserServices
{
    public interface IUserService
    {
        IEnumerable<UserListingViewModel> GetTopUsersCollection();

        IEnumerable<UserListingViewModel> GetUsersCollectionByString(string searchString);

        string GetUserIdByName(string name);
    }
}
