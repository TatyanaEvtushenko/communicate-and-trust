using System;

namespace CAT.DataLayer.Models
{
    public class TrainingLog
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Text { get; set; }

        public bool IsError { get; set; }

        public TrainingSession TrainingSession { get; set; }
    }
}
