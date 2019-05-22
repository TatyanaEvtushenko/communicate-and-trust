using System;
using CAT.DataLayer.Models.Enums;

namespace CAT.DataLayer.Models
{
    public class ActionLog
    {
        public int Id { get; set; }

        public User User { get; set; }

        public DateTime Date { get; set; }

        public ActionType ActionType { get; set; }

        public string Text { get; set; }
    }
}
