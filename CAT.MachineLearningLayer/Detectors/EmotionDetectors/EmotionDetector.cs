using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using CAT.MachineLearningLayer.Detectors.EmotionDetectors.Interfaces;
using CAT.MachineLearningLayer.Enums;
using CAT.MachineLearningLayer.NeuralNetworks.Builders;
using CAT.MachineLearningLayer.Options;
using CAT.MachineLearningLayer.Utils;
using Microsoft.Extensions.Options;
using OpenCvSharp;

namespace CAT.MachineLearningLayer.Detectors.EmotionDetectors
{
    public class EmotionDetector : IEmotionDetector
    {
        private readonly CascadeOption cascadeOptions;
        private readonly NeuralNetworkOption neuralNetworkOptions;

        public EmotionDetector(IOptions<CascadeOption> cascadeOptions,
            IOptions<NeuralNetworkOption> neuralNetworkOptions)
        {
            this.cascadeOptions = cascadeOptions.Value;
            this.neuralNetworkOptions = neuralNetworkOptions.Value;
        }

        public Emotion DetectEmotion(string imgPath)
        {
            //var sourceFolder = @"";
            //var imgPathes = Directory.GetFiles(sourceFolder);
            //foreach (var imgPathe in imgPathes)
            //{
            //    SaveImageFaces(imgPathe, neuralNetworkOptions.BaseFolder);
            //}
            SaveImageFaces(imgPath, neuralNetworkOptions.BaseFolder);
            TrainNeuralNetwork();
            return Emotion.Happiness;
        }

        public void TrainDetector(string imgPath, Emotion emotion)
        {
            throw new NotImplementedException();
        }

        private void SaveImageFaces(string imgPath, string facesFolder)
        {
            var faces = DetectFacesOnImage(imgPath);
            foreach (var faceRect in faces)
            {
                var img = PrepareImageForNeuralNetwork(imgPath, faceRect);
                var facePath = Path.Combine(facesFolder, "test1111.jpg");
                ImageEditor.SaveImage(img, facePath);
            }
        }

        private void TrainNeuralNetwork()
        {
            var builder = new ConvolutionNeuralNetworkBuilder();
            var preparedDataPath = Path.Combine(neuralNetworkOptions.BaseFolder, neuralNetworkOptions.PreparedDataFile);
            var modelPath = Path.Combine(neuralNetworkOptions.BaseFolder, neuralNetworkOptions.ModelFile);
            var numClasses = Enum.GetNames(typeof(Emotion)).Length - 1; //without "no faces" status
            NeuralNetworkManager.TrainModel(builder, preparedDataPath, modelPath, neuralNetworkOptions.ImageWidth, numClasses);
        }

        private IEnumerable<Rect> DetectFacesOnImage(string imgPath)
        {
            var srcImage = new Mat(imgPath);
            var normalizedImage = ImageFeaturesDetector.NormalizeImage(srcImage);
            normalizedImage.SaveImage("..\\CAT.BusinessLayer\\Test\\src.jpeg");
            //Cv2.Ima
            var faceClassifier = GetFaceClassifier();
            var faces = ImageFeaturesDetector.DetectObjects(faceClassifier, normalizedImage);
            return faces;
        }

        private CascadeClassifier GetFaceClassifier()
        {
            var faceCascadesPath = Path.Combine(cascadeOptions.BaseFolder, cascadeOptions.FaceCascadeFile);
            return ImageFeaturesDetector.GetClassifier(faceCascadesPath);
        }

        private Image PrepareImageForNeuralNetwork(string imgPath, Rect cropArea)
        {
            var imgWidth = neuralNetworkOptions.ImageWidth;
            var img = ImageEditor.CropImage(imgPath, cropArea);
            img = ImageEditor.ResizeImg(img, imgWidth, imgWidth);
            return img;
        }
    }
}
