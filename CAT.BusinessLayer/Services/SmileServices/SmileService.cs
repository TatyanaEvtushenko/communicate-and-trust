using System.Threading.Tasks;
using CAT.BusinessLayer.Services.SmileServices.Interfaces;
using CAT.DataLayer.Repositories.PhysicalRepositories.Interfaces;
using CAT.MachineLearningLayer.Detectors.EmotionDetectors.Interfaces;
using CAT.MachineLearningLayer.Enums;

namespace CAT.BusinessLayer.Services.SmileServices
{
    public class SmileService : ISmileService
    {
        private readonly IEmotionDetector _detector;
        private readonly IPhysicalRepository _physicalRepository;

        public SmileService(IEmotionDetector detector, IPhysicalRepository physicalRepository)
        {
            _detector = detector;
            _physicalRepository = physicalRepository;
        }

        public Emotion DetectEmotion(string imgBase64)
        {
            var filePath = _physicalRepository.SaveBase64ToTemporaryFile(imgBase64);
            var emotion = _detector.DetectEmotion(filePath);
            Task.Factory.StartNew(() => _physicalRepository.DeleteFile(filePath));
            return emotion;
        }
    }
}
