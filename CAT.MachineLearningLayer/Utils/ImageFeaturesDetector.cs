using OpenCvSharp;

namespace CAT.MachineLearningLayer.Utils
{
    internal class ImageFeaturesDetector
    {
        public static CascadeClassifier GetClassifier(string cascadePath)
        {
            return new CascadeClassifier(cascadePath);
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
    }
}
