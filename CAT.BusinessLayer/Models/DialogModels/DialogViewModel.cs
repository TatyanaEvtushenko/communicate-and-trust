using System.Collections.Generic;

namespace CAT.BusinessLayer.Models.DialogModels
{
    public class DialogViewModel
    {
        public bool IsOnline { get; set; }

        public List<MessageViewModel> Messages { get; set; }
    }
}
