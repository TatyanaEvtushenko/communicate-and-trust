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
        }

        public string Author { get; set; }

        public string Text { get; set; }

        public string PostDate { get; set; }
    }
}
