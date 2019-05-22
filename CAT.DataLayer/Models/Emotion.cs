using System;
using CAT.DataLayer.Models.Enums;

namespace CAT.DataLayer.Models
{
    public class Emotion
    {
        public int Id { get; set; }

        public EmotionType EmotionType { get; set; }

        public Guid Guid { get; set; }

        public int MessagePosition { get; set; }

        public Message Message { get; set; }
    }
}
