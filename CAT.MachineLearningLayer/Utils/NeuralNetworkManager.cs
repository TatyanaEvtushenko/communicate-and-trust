using System;
using System.Collections.Generic;
using System.Linq;
using CAT.MachineLearningLayer.NeuralNetworks.Builders.Interfaces;
using CAT.MachineLearningLayer.NeuralNetworks.Models;
using CNTK;

namespace CAT.MachineLearningLayer.Utils
{
    internal static class NeuralNetworkManager
    {
        private const string FeatureStreamName = "features";
        private const string LabelsStreamName = "labels";
        private const string ClassifierName = "classifierOutput";

        public static void TrainModel(INeuralNetworkBuilder networkBuilder, string preparedDataPath, string modelPath,
            int imageWidth, int numClasses)
        {
            //var device = DeviceDescriptor.GPUDevice(0);
            var device = DeviceDescriptor.CPUDevice;
            var imageDim = GetImageDim(imageWidth);
            var buildOutput = networkBuilder.Build(device, FeatureStreamName, LabelsStreamName, ClassifierName,
                numClasses, imageDim);
            var imageSize = GetImageSize(imageWidth);
            var preparedData = new PreparedDataInfo(preparedDataPath, FeatureStreamName, LabelsStreamName, imageSize,
                numClasses, MinibatchSource.InfinitelyRepeat);
            var trainer = CreateTrainer(buildOutput);
            TrainModel(device, preparedData, buildOutput, trainer);
            SaveModel(buildOutput, modelPath);

            // validate the model
            var preparedNewData = new PreparedDataInfo(preparedDataPath, FeatureStreamName, LabelsStreamName, imageSize,
                numClasses, MinibatchSource.FullDataSweep);
            ValidateModelWithMinibatchSource(modelPath, imageDim, numClasses, preparedNewData, FeatureStreamName, device);
        }

        private static int[] GetImageDim(int imageWidth)
        {
            return new[] {imageWidth, imageWidth, 1};
        }

        private static int GetImageSize(int imageWidth)
        {
            return imageWidth * imageWidth;
        }

        public static void Main()
        {
            var device = DeviceDescriptor.GPUDevice(0);

            Console.WriteLine(
                $"======== running MNISTClassifier.TrainAndEvaluate with convolutional neural network using {device.Type} ========");
            TrainAndEvaluate(device, true);
        }

        /// <summary>
        /// Train and evaluate a image classifier for MNIST data.
        /// </summary>
        /// <param name="device">CPU or GPU device to run training and evaluation</param>
        /// <param name="forceRetrain">whether to override an existing model.
        /// if true, any existing model will be overridden and the new one evaluated. 
        /// if false and there is an existing model, the existing model is evaluated.</param>
        public static void TrainAndEvaluate(DeviceDescriptor device, bool forceRetrain)
        {
            //// If a model already exists and not set to force retrain, validate the model and return.
            //if (File.Exists(CNNCommon.ModelFile) && !forceRetrain)
            //{
            //    var minibatchSourceExistModel = MinibatchSource.TextFormatMinibatchSource(
            //        Path.Combine(CNNCommon.ImageDataFolder, "Test_cntk_text.txt"), CNNConfiguration.StreamConfigurations);
            //    TestHelper.ValidateModelWithMinibatchSource(modelFile, minibatchSourceExistModel,
            //        imageDim, numClasses, featureStreamName, labelsStreamName, classifierName, device);
            //    return;
            //}

            //var builder = new ConvolutionalNeuralNetworkBuilder();
            //var buildOutput = builder.Build(device);

            //// prepare training data
            //var preparedData = new PreparedDataInfo(CNNConfiguration.FeatureStreamName,
            //    CNNConfiguration.LabelsStreamName, CNNCommon.PreparedDataPath,
            //    CNNConfiguration.StreamConfigurations, MinibatchSource.InfinitelyRepeat);

            //// set per sample learning rate
            //var trainer = CreateTrainer(buildOutput);

            ////
            //const uint minibatchSize = 64;
            //const int outputFrequencyInMinibatches = 20;
            //var i = 0;
            //var epochs = 5;
            //while (epochs > 0)
            //{
            //    var minibatchData = preparedData.MinibatchSource.GetNextMinibatch(minibatchSize, device);
            //    var arguments = new Dictionary<Variable, MinibatchData>
            //    {
            //        {buildOutput.Input, minibatchData[preparedData.FeatureStreamInfo]},
            //        {buildOutput.Labels, minibatchData[preparedData.LabelStreamInfo]}
            //    };

            //    trainer.TrainMinibatch(arguments, device);
            //    PrintTrainingProgress(trainer, i++, outputFrequencyInMinibatches);

            //    // MinibatchSource is created with MinibatchSource.InfinitelyRepeat.
            //    // Batching will not end. Each time minibatchSource completes an sweep (epoch),
            //    // the last minibatch data will be marked as end of a sweep. We use this flag
            //    // to count number of epochs.
            //    if (MiniBatchDataIsSweepEnd(minibatchData.Values))
            //    {
            //        epochs--;
            //    }
            //}

            //// save the trained model
            //buildOutput.ClassifierOutput.Save(CNNCommon.ModelFile);

            // validate the model
            //var preparedNewData = new PreparedDataInfo(CNNConfiguration.FeatureStreamName,
            //    CNNConfiguration.LabelsStreamName, CNNCommon.PreparedDataPath,
            //    CNNConfiguration.StreamConfigurations, MinibatchSource.FullDataSweep);
            //ValidateModelWithMinibatchSource(CNNCommon.ModelFile, CNNConfiguration.ImageDim,
            //    CNNConfiguration.NumClasses, preparedNewData, CNNConfiguration.FeatureStreamName, device);
        }

        private static Trainer CreateTrainer(NetworkBuildOutput buildOutput)
        {
            var parameters = buildOutput.ClassifierOutput.Parameters();
            var parameterLearners = CreateLerners(parameters);
            var trainer = Trainer.CreateTrainer(buildOutput.ClassifierOutput, buildOutput.TrainingLoss,
                buildOutput.Prediction, parameterLearners);
            return trainer;
        }

        private static List<Learner> CreateLerners(IList<Parameter> parameters)
        {
            var learningRatePerSample = new TrainingParameterScheduleDouble(0.003125, 1);
            var learner = Learner.SGDLearner(parameters, learningRatePerSample);
            return new List<Learner> {learner};
        }

        private static void TrainModel(DeviceDescriptor device, PreparedDataInfo preparedData,
            NetworkBuildOutput buildOutput, Trainer trainer)
        {
            const uint minibatchSize = 64;
            const int outputFrequencyInMinibatches = 20;
            var i = 0;
            var epochs = 5;
            while (epochs > 0)
            {
                var minibatchData = preparedData.MinibatchSource.GetNextMinibatch(minibatchSize, device);
                var arguments = new Dictionary<Variable, MinibatchData>
                {
                    {buildOutput.Input, minibatchData[preparedData.FeatureStreamInfo]},
                    {buildOutput.Labels, minibatchData[preparedData.LabelStreamInfo]}
                };

                trainer.TrainMinibatch(arguments, device);
                PrintTrainingProgress(trainer, i++, outputFrequencyInMinibatches);

                // MinibatchSource is created with MinibatchSource.InfinitelyRepeat.
                // Batching will not end. Each time minibatchSource completes an sweep (epoch),
                // the last minibatch data will be marked as end of a sweep. We use this flag
                // to count number of epochs.
                if (MiniBatchDataIsSweepEnd(minibatchData.Values))
                {
                    epochs--;
                }
            }
        }

        private static void SaveModel(NetworkBuildOutput buildOutput, string modelFile)
        {
            buildOutput.ClassifierOutput.Save(modelFile);
        }

        private static void PrintTrainingProgress(Trainer trainer, int minibatchIdx, int outputFrequencyInMinibatches)
        {
            if (minibatchIdx % outputFrequencyInMinibatches != 0 || trainer.PreviousMinibatchSampleCount() == 0)
            {
                return;
            }
            var trainLossValue = (float) trainer.PreviousMinibatchLossAverage();
            var evaluationValue = (float) trainer.PreviousMinibatchEvaluationAverage();
            Console.WriteLine(
                $"Minibatch: {minibatchIdx} CrossEntropyLoss = {trainLossValue}, EvaluationCriterion = {evaluationValue}");
        }

        private static bool MiniBatchDataIsSweepEnd(ICollection<MinibatchData> minibatchValues)
        {
            return minibatchValues.Any(a => a.sweepEnd);
        }

        public static float ValidateModelWithMinibatchSource(
            string modelFile, int[] imageDim, int numClasses, PreparedDataInfo preparedData, string outputName,
            DeviceDescriptor device, int maxCount = 1000)
        {
            var model = Function.Load(modelFile, device);
            var imageInput = model.Arguments[0];
            var labelOutput = model.Outputs.Single(o => o.Name == outputName);

            const int batchSize = 50;
            int miscountTotal = 0, totalCount = 0;
            while (true)
            {
                var minibatchData = preparedData.MinibatchSource.GetNextMinibatch((uint) batchSize, device);
                if (minibatchData == null || minibatchData.Count == 0)
                    break;
                totalCount += (int) minibatchData[preparedData.FeatureStreamInfo].numberOfSamples;

                // expected labels are in the minibatch data.
                var labelData = minibatchData[preparedData.LabelStreamInfo].data.GetDenseData<float>(labelOutput);
                var expectedLabels = labelData.Select(l => l.IndexOf(l.Max())).ToList();

                var inputDataMap = new Dictionary<Variable, Value>
                {
                    {imageInput, minibatchData[preparedData.FeatureStreamInfo].data}
                };

                var outputDataMap = new Dictionary<Variable, Value>
                {
                    {labelOutput, null}
                };

                model.Evaluate(inputDataMap, outputDataMap, device);
                var outputData = outputDataMap[labelOutput].GetDenseData<float>(labelOutput);
                var actualLabels = outputData.Select(l => l.IndexOf(l.Max())).ToList();

                int misMatches = actualLabels.Zip(expectedLabels, (a, b) => a.Equals(b) ? 0 : 1).Sum();

                miscountTotal += misMatches;
                Console.WriteLine(
                    $"Validating Model: Total Samples = {totalCount}, Misclassify Count = {miscountTotal}");

                if (totalCount > maxCount)
                    break;
            }

            var errorRate = 1.0F * miscountTotal / totalCount;
            Console.WriteLine($"Model Validation Error = {errorRate}");
            return errorRate;
        }
    }
}