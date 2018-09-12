using System;
using System.Linq;
using CAT.MachineLearningLayer.Detectors.EmotionDetectors.Interfaces;
using CAT.MachineLearningLayer.Enums;
using CAT.MachineLearningLayer.Options;
using CAT.MachineLearningLayer.Utils;
using Microsoft.Extensions.Options;
using OpenCvSharp;

namespace CAT.MachineLearningLayer.Detectors.EmotionDetectors
{
    public class EmotionDetector : IEmotionDetector
    {
        private readonly CascadeClassifier _faceClassifier;
        private readonly CascadeClassifier _eyeClassifier;

        public EmotionDetector(IOptions<CascadeOption> option)
        {
            var helper = new ClassifierHelper(option.Value.BaseFolder);
            _faceClassifier = helper.GetClassifier(option.Value.FaceCascadeFile);
            _eyeClassifier = helper.GetClassifier(option.Value.EyeCascadeFile);
        }

        public Emotion DetectEmotion(string imgPath)
        {
            var srcImage = new Mat(imgPath);
            var normalizedImage = ClassifierHelper.NormalizeImage(srcImage);
            var faces = ClassifierHelper.DetectObjects(_faceClassifier, normalizedImage);
            var smiles = faces.Select(x => DetectSmile(normalizedImage, x));
            throw new NotImplementedException();
        }

        private Rect[] DetectSmile(Mat srcImage, Rect faceRect)
        {
            var faceImage = new Mat(srcImage, faceRect);
            var normalizedFaceImage = ClassifierHelper.NormalizeImage(faceImage);
            var eyes = ClassifierHelper.DetectObjects(_eyeClassifier, faceImage);
            return null;
        }
    }
}
