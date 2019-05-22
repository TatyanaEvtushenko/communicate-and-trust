using System;
using System.Collections.Generic;
using CAT.DataLayer.Models.Enums;

namespace CAT.DataLayer.Models
{
    public class TestSession
    {
        public int Id { get; set; }

        public User User { get; set; }

        public DateTime StartDate { get; set; }

        public EmotionType Type { get; set; }

        public EmotionType ResultType { get; set; }

        public bool IsValid { get; set; }

        public ICollection<TestLog> TestLogs { get; set; } = new List<TestLog>();
    }
}
