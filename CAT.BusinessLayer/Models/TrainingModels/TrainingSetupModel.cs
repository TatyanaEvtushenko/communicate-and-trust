using System;

namespace CAT.BusinessLayer.Models.TrainingModels
{
    public class TrainingSetupModel
    {
        public string UserName { get; set; }

        public string SelectedEmotion { get; set; }

        public string[] Sources { get; set; }

        public DateTime StartDate { get; set; }
    }
}
