using CAT.MachineLearningLayer.Enums;

namespace CAT.MachineLearningLayer.Detectors.EmotionDetectors.Interfaces
{
    public interface IEmotionDetector
    {
        Emotion DetectEmotion(string imgPath);
    }
}
