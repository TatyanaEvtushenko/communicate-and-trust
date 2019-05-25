using System.Globalization;
using CAT.DataLayer.Models;

namespace CAT.BusinessLayer.Models.DialogModels
{
    public class MessageViewModel
    {
        public MessageViewModel()
        {
            
        }

        public MessageViewModel(Message message)
        {
            Author = message.Sender.UserName;
            Text = message.Text;
            PostDate = message.Date.ToString(CultureInfo.InvariantCulture);
            IsReaction = message.IsReaction;
            IsRead = message.IsRead;
        }

        public string Author { get; set; }

        public string To { get; set; }

        public string Text { get; set; }

        public string PostDate { get; set; }

        public bool IsReaction { get; set; }

        public bool IsRead { get; set; }
    }
}
