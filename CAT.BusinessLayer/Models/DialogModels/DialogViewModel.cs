using System.Collections.Generic;

namespace CAT.BusinessLayer.Models.DialogModels
{
    public class DialogViewModel
    {
        public bool IsOnline { get; set; }

        public string Name { get; set; }

        public string Avatar { get; set; }

        public List<MessageViewModel> Messages { get; set; }
    }
}
