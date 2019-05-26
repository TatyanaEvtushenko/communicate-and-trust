using System.Collections.Generic;
using System.Linq;
using CAT.BusinessLayer.Models.UserModels.ViewModels;
using CAT.DataLayer.Models;
using CAT.DataLayer.Repositories.DatabaseRepositories.Interfaces;

namespace CAT.BusinessLayer.Services.UserServices.Implementations
{
    public class UserService : IUserService
    {
        private readonly IDatabaseRepository<User> userRepository;

        public UserService(IDatabaseRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }

        public IEnumerable<UserListingViewModel> GetTopUsersCollection()
        {
            return userRepository.QueryableList().Take(10)
                .Select(x => new UserListingViewModel(x)).ToList();
        }

        public IEnumerable<UserListingViewModel> GetUsersCollectionByString(string searchString)
        {
            return userRepository.QueryableList()
                .Where(x => IsUserAvailable(x, searchString))
                .Select(x => new UserListingViewModel(x)).ToList();
        }

        public string GetUserIdByName(string name)
        {
            return GetUserByName(name)?.Id;
        }

        public User GetUserByName(string name)
        {
            return userRepository.GetFirst(x => x.UserName == name);
        }

        private bool IsUserAvailable(User user, string searchString)
        {
            var userName = user.UserName.ToLower();
            var fullName = $"{user.FirstName} {user.SecondName}".ToLower();
            var search = searchString.ToLower();

            return userName.Contains(search) || fullName.Contains(search);
        }
    }
}
