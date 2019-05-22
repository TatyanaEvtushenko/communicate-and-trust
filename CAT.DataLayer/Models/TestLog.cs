using System;

namespace CAT.DataLayer.Models
{
    public class TestLog
    {
        public int Id { get; set; }

        public TestSession TestSession { get; set; }

        public DateTime Date { get; set; }

        public string Text { get; set; }

        public bool IsError { get; set; }
    }
}
