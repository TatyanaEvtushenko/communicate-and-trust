using CAT.BusinessLayer.Services.SmileServices.Interfaces;
using CAT.MachineLearningLayer.Detectors.EmotionDetectors.Interfaces;
using CAT.MachineLearningLayer.Enums;

namespace CAT.BusinessLayer.Services.SmileServices
{
    public class TestSmileService : ISmileService
    {
        private readonly IEmotionDetector _detector;

        public TestSmileService(IEmotionDetector detector)
        {
            _detector = detector;
        }

        public Emotion DetectEmotion(string imgBase64)
        {
            return _detector.DetectEmotion(@"..\CAT.BusinessLayer\Test\Test.jpg");
        }
    }
}
