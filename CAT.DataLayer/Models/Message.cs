using System;
using System.Collections.Generic;

namespace CAT.DataLayer.Models
{
    public class Message
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Text { get; set; }

        public bool IsRead { get; set; }

        public User Sender { get; set; }

        public Dialog Dialog { get; set; }

        public ICollection<Emotion> Emotions { get; set; } = new List<Emotion>();
    }
}
