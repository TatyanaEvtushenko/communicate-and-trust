using System.Collections.Generic;
using CAT.DataLayer.Models.Enums;
using Microsoft.AspNetCore.Identity;

namespace CAT.DataLayer.Models
{
    public class User : IdentityUser
    {
        public UserAvailabilityStatus AvailabilityStatus { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string AvatarUrl { get; set; }

        public ICollection<UserDialog> UserDialogs { get; set; } = new List<UserDialog>();

        public ICollection<TrainingSession> TrainingSessions { get; set; } = new List<TrainingSession>();

        public ICollection<TestSession> TestSessions { get; set; } = new List<TestSession>();

        public ICollection<ActionLog> ActionLogs { get; set; } = new List<ActionLog>();
    }
}
