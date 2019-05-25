using CAT.BusinessLayer.Models.DialogModels;
using CAT.DataLayer.Models;

namespace CAT.BusinessLayer.Services.MessageServices
{
    public interface IMessageService
    {
        void PostMessage(MessageViewModel message, User sender, Dialog dialog);

        bool ReadAllMessages(string firstUserId, string secondUserId);
    }
}
