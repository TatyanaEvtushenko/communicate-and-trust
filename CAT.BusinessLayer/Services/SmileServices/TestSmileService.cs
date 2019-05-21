using CAT.BusinessLayer.Services.SmileServices.Interfaces;
using CAT.MachineLearningLayer.Detectors.EmotionDetectors.Interfaces;
using CAT.MachineLearningLayer.Enums;

namespace CAT.BusinessLayer.Services.SmileServices
{
    public class TestSmileService : ISmileService
    {
        private readonly IEmotionDetector detector;

        public TestSmileService(IEmotionDetector detector)
        {
            this.detector = detector;
        }

        public Emotion DetectEmotion(string imgBase64)
        {
            return detector.DetectEmotion(@"..\CAT.BusinessLayer\Test\Test.jpg");
        }
    }
}
