using CAT.DataLayer.Models.Enums;

namespace CAT.BusinessLayer.Utils.Emotion
{
    public static class EmotionUtil
    {
        public static EmotionType GetEmotionType(string emotion)
        {
            switch (emotion)
            {
                case "anger":
                    return EmotionType.Anger;
                case "contempt":
                    return EmotionType.Contempt;
                case "disgust":
                    return EmotionType.Disgust;
                case "fear":
                    return EmotionType.Fear;
                case "happiness":
                    return EmotionType.Happiness;
                case "neutral":
                    return EmotionType.Neutral;
                case "sadness":
                    return EmotionType.Sadness;
                case "surprise":
                    return EmotionType.Surprise;
                default:
                    return EmotionType.Neutral;
            }
        }
    }
}
