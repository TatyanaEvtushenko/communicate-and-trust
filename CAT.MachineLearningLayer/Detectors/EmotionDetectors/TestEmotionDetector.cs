using System;
using CAT.MachineLearningLayer.Detectors.EmotionDetectors.Interfaces;
using CAT.MachineLearningLayer.Enums;

namespace CAT.MachineLearningLayer.Detectors.EmotionDetectors
{
    public class TestEmotionDetector : IEmotionDetector
    {
        public Emotion DetectEmotion(string imgPath)
        {
            var rand = new Random();
            var enumType = typeof(Emotion);
            var emotions = Enum.GetNames(enumType);
            var emotionIndex = rand.Next(emotions.Length);
            return (Emotion) Enum.Parse(enumType, emotions[emotionIndex]);
        }
    }
}
