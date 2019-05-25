namespace CAT.BusinessLayer.Models.DialogModels
{
    public class DialogListingViewModel
    {
        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string Login { get; set; }

        public bool IsOnline { get; set; }

        public string AvatarUrl { get; set; }

        public MessageViewModel LastMessage { get; set; }
    }
}
