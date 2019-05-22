using System;
using System.Collections.Generic;

namespace CAT.DataLayer.Models
{
    public class Dialog
    {
        public int Id { get; set; }
        
        public DateTime StartDate { get; set; }

        public ICollection<UserDialog> UserDialogs { get; set; } = new List<UserDialog>();

        public ICollection<Message> Messages { get; set; } = new List<Message>();
    }
}
