using System;
using System.Collections.Generic;
using CAT.DataLayer.Models.Enums;

namespace CAT.DataLayer.Models
{
    public class TrainingSession
    {
        public int Id { get; set; }

        public User User { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public TrainingSessionStatus Status { get; set; }

        public ICollection<TrainingSource> TrainingSources { get; set; } = new List<TrainingSource>();

        public ICollection<TrainingLog> TrainingLogs { get; set; } = new List<TrainingLog>();
    }
}
