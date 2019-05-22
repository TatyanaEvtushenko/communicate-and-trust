using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using CAT.BusinessLayer.Models.DialogModels;
using CAT.DataLayer.Models;
using CAT.DataLayer.Models.Enums;
using CAT.DataLayer.Repositories.DatabaseRepositories.Interfaces;

namespace CAT.BusinessLayer.Services.DialogServices.Implementations
{
    public class DialogService : IDialogService
    {
        private readonly IDatabaseRepository<Dialog> dialogRepository;
        private readonly IDatabaseRepository<User> userRepository;

        public DialogService(IDatabaseRepository<Dialog> dialogRepository, IDatabaseRepository<User> userRepository)
        {
            this.dialogRepository = dialogRepository;
            this.userRepository = userRepository;
        }

        public IEnumerable<DialogListingViewModel> GetUserDialogs(string userId)
        {
            return new List<DialogListingViewModel>();
        }

        public DialogViewModel GetDialog(string firstUserId, string secondUserId)
        {
            var dialog = dialogRepository.GetFirst(x =>
                x.UserDialogs.All(y => y.User.Id == firstUserId || y.User.Id == secondUserId));
            if (dialog == null)
            {
                return GetNewDialogViewModel(secondUserId);
            }

            return GetDialogViewModel(secondUserId, dialog);
        }

        private DialogViewModel GetDialogViewModel(string userId, Dialog dialog)
        {
            return new DialogViewModel
            {
                IsOnline = userRepository.GetFirst(x=>x.Id == userId).AvailabilityStatus ==
                           UserAvailabilityStatus.Online,
                Messages = dialog.Messages.Select(x => new MessageViewModel(x)).ToList()
            };
        }

        private DialogViewModel GetNewDialogViewModel(string userId)
        {
            return new DialogViewModel
            {
                IsOnline = userRepository.GetFirst(x => x.Id == userId).AvailabilityStatus ==
                           UserAvailabilityStatus.Online,
                Messages = new List<MessageViewModel>()
            };
        }
    }
}
