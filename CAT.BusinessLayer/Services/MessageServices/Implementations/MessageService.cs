using System;
using System.Linq;
using CAT.BusinessLayer.Models.DialogModels;
using CAT.BusinessLayer.Services.DialogServices;
using CAT.DataLayer.Models;
using CAT.DataLayer.Repositories.DatabaseRepositories.Interfaces;

namespace CAT.BusinessLayer.Services.MessageServices.Implementations
{
    public class MessageService : IMessageService
    {
        private readonly IDatabaseRepository<Message> messageRepository;
        private readonly IDialogService dialogService;

        public MessageService(IDatabaseRepository<Message> messageRepository, IDialogService dialogService)
        {
            this.messageRepository = messageRepository;
            this.dialogService = dialogService;
        }

        public void PostMessage(MessageViewModel message, User sender, Dialog dialog)
        {
            messageRepository.Add(new Message
            {
                Date = DateTime.Parse(message.PostDate),
                IsReaction = message.IsReaction,
                IsRead = false,
                Sender = sender,
                Dialog = dialog,
                Text = message.Text
            });
        }

        public bool ReadAllMessages(string firstUserId, string secondUserId)
        {
            var reactionIsNeeded = false;
            var dialog = dialogService.GetDomainDialog(firstUserId, secondUserId);
            var unreadMessages = dialog.Messages.Where(x => x.Sender.Id != firstUserId && !x.IsRead);
            foreach (var message in unreadMessages)
            {
                message.IsRead = true;
                messageRepository.Update(message);
                reactionIsNeeded = true;
            }

            return reactionIsNeeded;
        }
    }
}
