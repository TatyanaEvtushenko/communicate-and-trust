using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using OpenCvSharp;

namespace CAT.MachineLearningLayer.Utils
{
    internal static class ImageEditor
    {
        public static Image CropImage(string imgPath, Rect cropArea)
        {
            var cropRectangle = new Rectangle(cropArea.X, cropArea.Y, cropArea.Width, cropArea.Height);
            return CropImage(imgPath, cropRectangle);
        }

        public static Image CropImage(string imgPath, Rectangle cropArea)
        {
            var bmpImage = new Bitmap(imgPath);
            return bmpImage.Clone(cropArea, bmpImage.PixelFormat);
        }

        public static Image ResizeImg(Image image, int nWidth, int nHeight)
        {
            Image resizedImage = new Bitmap(nWidth, nHeight);
            using (var graphic = Graphics.FromImage(resizedImage))
            {
                graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphic.DrawImage(image, 0, 0, nWidth, nHeight);
                graphic.Dispose();
            }
            return resizedImage;
        }

        public static void SaveImage(Image image, string imgPath)
        {
            using (var stream = File.Create(imgPath))
            {
                image.Save(stream, ImageFormat.Jpeg);
            }
        }
    }
}
