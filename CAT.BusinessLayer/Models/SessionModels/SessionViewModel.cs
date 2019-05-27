using System;

namespace CAT.BusinessLayer.Models.SessionModels
{
    public class SessionViewModel
    {
        public bool IsTest { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string[] Sources { get; set; }

        public string[] Logs { get; set; }

        public string SelectedEmotionType { get; set; }

        public string ReturnedEmotionType { get; set; }
    }
}
