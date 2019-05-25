using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using CAT.BusinessLayer.Models.DialogModels;
using CAT.BusinessLayer.Services.UserServices;
using CAT.DataLayer.Models;
using CAT.DataLayer.Models.Enums;
using CAT.DataLayer.Repositories.DatabaseRepositories.Interfaces;

namespace CAT.BusinessLayer.Services.DialogServices.Implementations
{
    public class DialogService : IDialogService
    {
        private readonly IDatabaseRepository<Dialog> dialogRepository;
        private readonly IDatabaseRepository<User> userRepository;

        public DialogService(
            IDatabaseRepository<Dialog> dialogRepository,
            IDatabaseRepository<User> userRepository)
        {
            this.dialogRepository = dialogRepository;
            this.userRepository = userRepository;
        }

        public IEnumerable<DialogListingViewModel> GetUserDialogs(string userId)
        {
            var dialogs = GetDomainDialogs(userId);
            var result = new List<DialogListingViewModel>();
            foreach (var dialog in dialogs)
            {
                var anotherUser = dialog.UserDialogs.First(x => x.User.Id != userId).User;
                result.Add(new DialogListingViewModel
                {
                    FirstName = anotherUser.FirstName,
                    SecondName = anotherUser.SecondName,
                    AvatarUrl = anotherUser.AvatarUrl,
                    IsOnline = anotherUser.AvailabilityStatus == UserAvailabilityStatus.Online,
                    Login = anotherUser.UserName,
                    LastMessage = new MessageViewModel(dialog.Messages.OrderBy(x => x.Date).Last())
                });    
            }

            return result;
        }

        public DialogViewModel GetDialog(string firstUserId, string secondUserId)
        {
            var dialog = GetDomainDialog(firstUserId, secondUserId);
            if (dialog == null)
            {
                dialog = CreateDomainDialog(firstUserId, secondUserId);
                dialogRepository.Add(dialog);
                return GetDialogViewModel(secondUserId, dialog);
            }

            return GetDialogViewModel(secondUserId, dialog);
        }

        public Dialog GetDomainDialog(string firstUserId, string secondUserId)
        {
            var dialog = dialogRepository.GetFirst(x =>
                x.UserDialogs.All(y => y.User.Id == firstUserId || y.User.Id == secondUserId));
            
            return dialog;
        }

        public IEnumerable<Dialog> GetDomainDialogs(string userId)
        {
            var dialogs = dialogRepository.QueryableList().Where(x => x.UserDialogs.Any(y => y.User.Id == userId));

            return dialogs;
        }

        private DialogViewModel GetDialogViewModel(string userId, Dialog dialog)
        {
            var user = userRepository.GetFirst(x => x.Id == userId);
            return new DialogViewModel
            {
                IsOnline = user.AvailabilityStatus == UserAvailabilityStatus.Online,
                Name = $"{user.FirstName} {user.SecondName}",
                Avatar = user.AvatarUrl,
                Messages = dialog.Messages.Select(x => new MessageViewModel(x)).ToList()
            };
        }

        private Dialog CreateDomainDialog(string firstUserId, string secondUserId)
        {
            var firstUser = userRepository.GetFirst(x => x.Id == firstUserId);
            var secondUser = userRepository.GetFirst(x => x.Id == secondUserId);
            var dialog = new Dialog
            {
                Messages = new List<Message>(),
                StartDate = DateTime.Now
            };
            var listOfUserDialogs = new List<UserDialog>
            {
                new UserDialog {Dialog = dialog, User = firstUser},
                new UserDialog {Dialog = dialog, User = secondUser}
            };
            dialog.UserDialogs = listOfUserDialogs;

            return dialog;
        }
    }
}
