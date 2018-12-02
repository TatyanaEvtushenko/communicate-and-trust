using OpenCvSharp;

namespace CAT.MachineLearningLayer.Utils
{
    internal class ClassifierHelper
    {
        private readonly string _cascadesFolderPath;

        public ClassifierHelper(string baseCascadesFolderPath)
        {
            _cascadesFolderPath = baseCascadesFolderPath;
        }

        public static Mat NormalizeImage(Mat srcImage)
        {
            var normalizedImage = new Mat();
            Cv2.CvtColor(srcImage, normalizedImage, ColorConversionCodes.BGRA2GRAY);
            Cv2.EqualizeHist(normalizedImage, normalizedImage);
            return normalizedImage;
        }

        public static Rect[] DetectObjects(CascadeClassifier classifier, Mat srcImage)
        {
            return classifier.DetectMultiScale(
                image: srcImage,
                scaleFactor: 1.1,
                minNeighbors: 2,
                flags: HaarDetectionType.DoRoughSearch | HaarDetectionType.ScaleImage,
                minSize: new Size(30, 30)
            );
        }

        public CascadeClassifier GetClassifier(string cascadeName)
        {
            return new CascadeClassifier(_cascadesFolderPath + cascadeName);
        }
    }
}
