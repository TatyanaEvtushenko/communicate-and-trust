using CAT.MachineLearningLayer.Enums;

namespace CAT.BusinessLayer.Services.SmileServices.Interfaces
{
    public interface ISmileService
    {
        Emotion DetectEmotion(string imgBase64);
    }
}
