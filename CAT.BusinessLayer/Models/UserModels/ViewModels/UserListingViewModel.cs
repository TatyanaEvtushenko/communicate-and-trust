namespace CAT.BusinessLayer.Models.UserModels.ViewModels
{
    public class UserListingViewModel
    {
        public UserListingViewModel(DataLayer.Models.User user)
        {
            Name = user.UserName;
            FirstName = user.FirstName;
            SecondName = user.SecondName;
            Avatar = user.AvatarUrl;
        }

        public string Name { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string Avatar { get; set; }
    }
}
