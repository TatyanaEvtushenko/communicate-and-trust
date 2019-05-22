using System.Linq;
using CAT.MachineLearningLayer.ConvolutionNeuralNetwork.Configurations;
using CAT.MachineLearningLayer.NeuralNetworks.Builders.Configurations.CNN.Models;
using CAT.MachineLearningLayer.NeuralNetworks.Builders.Interfaces;
using CAT.MachineLearningLayer.NeuralNetworks.Enums;
using CAT.MachineLearningLayer.NeuralNetworks.Models;
using CAT.MachineLearningLayer.NeuralNetworks.Utils;
using CNTK;

namespace CAT.MachineLearningLayer.NeuralNetworks.Builders
{
    internal class ConvolutionNeuralNetworkBuilder : INeuralNetworkBuilder
    {
        public NetworkBuildOutput Build(DeviceDescriptor device, string featureStreamName, string labelsStreamName,
            string classifierName, int numClasses, int[] imageDim)
        {
            var buildOutput = new NetworkBuildOutput();
            buildOutput.Input = CNTKLib.InputVariable(imageDim, DataType.Float, featureStreamName);
            buildOutput.ScaledInput = CNTKLib.ElementTimes(Constant.Scalar(0.00390625f, device), buildOutput.Input);
            buildOutput.ClassifierOutput = CreateConvolutionNeuralNetwork(buildOutput.ScaledInput,
                numClasses, device, classifierName);
            buildOutput.Labels = CNTKLib.InputVariable(new[] {numClasses}, DataType.Float, labelsStreamName);
            buildOutput.TrainingLoss = CNTKLib.CrossEntropyWithSoftmax(new Variable(buildOutput.ClassifierOutput),
                buildOutput.Labels, "lossFunction");
            buildOutput.Prediction = CNTKLib.ClassificationError(new Variable(buildOutput.ClassifierOutput),
                buildOutput.Labels, "classificationError");
            return buildOutput;
        }

        /// <summary>
        /// Create convolution neural network
        /// </summary>
        /// <param name="features">input feature variable</param>
        /// <param name="outDims">number of output classes</param>
        /// <param name="device">CPU or GPU device to run the model</param>
        /// <param name="classifierName">name of the classifier</param>
        /// <returns>the convolution neural network classifier</returns>
        private static Function CreateConvolutionNeuralNetwork(Variable features, int outDims, DeviceDescriptor device,
            string classifierName)
        {
            var previousLayer = features;
            foreach (var configuration in ConvolutionNeuralNetworkConfiguration.ConvolutionWithPoolingLayers)
            {
                var currentLayer = ConvolutionWithPooling(previousLayer, device, configuration);
                previousLayer = currentLayer;
            }

            var denseLayer = Dense(previousLayer, outDims, device,
                ConvolutionNeuralNetworkConfiguration.DenseActivationFunction, classifierName);
            return denseLayer;
        }

        private static Function ConvolutionWithPooling(Variable features, DeviceDescriptor device,
            ConvolutionWithPoolingConfigurationModel configuration)
        {
            var convFunction = ConvolutionWithActivation(features, device, configuration.Convolution);
            var poolingFunction = Pooling(convFunction, configuration.Pooling);
            return poolingFunction;
        }

        private static Function ConvolutionWithActivation(Variable features, DeviceDescriptor device,
            ConvolutionConfigurationModel configuration)
        {
            var convFunction = Convolution(features, device, configuration);
            var convWithActivationFunction =
                BuilderHelper.GetActivationFunction(configuration.ActivationFunction, convFunction);
            return convWithActivationFunction;
        }

        private static Function Convolution(Variable features, DeviceDescriptor device,
            ConvolutionConfigurationModel configuration)
        {
            // parameter initialization hyper parameter
            const double convWScale = 0.26;
            var convParams = new Parameter(new[]
                {
                    configuration.KernelHeight, configuration.KernelWidth,
                    configuration.InputChannelsCount, configuration.OutFeatureMapCount
                },
                DataType.Float,
                CNTKLib.GlorotUniformInitializer(convWScale, -1, 2), device);
            var strides = new[] {1, 1, configuration.InputChannelsCount};
            var convFunction = CNTKLib.Convolution(convParams, features, strides);
            return convFunction;
        }

        private static Function Pooling(Variable convFunction, PoolingConfigurationModel configuration)
        {
            var windowShape = new[] {configuration.WindowHeight, configuration.WindowWidth};
            var strides = new[] {configuration.StrideByHeight, configuration.StrideByWidth};
            var pooling = CNTKLib.Pooling(convFunction, configuration.PoolingType, windowShape, strides, new[] { true });
            return pooling;
        }

        private static Function Dense(Variable input, int outputDim, DeviceDescriptor device,
            ActivationFunction activationFunction, string outputName)
        {
            if (input.Shape.Rank != 1)
            {
                var newDim = input.Shape.Dimensions.Aggregate((d1, d2) => d1 * d2);
                input = CNTKLib.Reshape(input, new [] { newDim });
            }

            var fullyConnected = FullyConnectedLinearLayer(input, outputDim, device, outputName);
            return BuilderHelper.GetActivationFunction(activationFunction, fullyConnected);
        }

        private static Function FullyConnectedLinearLayer(Variable input, int outputDim, DeviceDescriptor device,
            string outputName)
        {
            System.Diagnostics.Debug.Assert(input.Shape.Rank == 1);
            var inputDim = input.Shape[0];

            int[] s = { outputDim, inputDim };
            var timesParam = new Parameter((NDShape)s, DataType.Float,
                CNTKLib.GlorotUniformInitializer(
                    CNTKLib.DefaultParamInitScale,
                    CNTKLib.SentinelValueForInferParamInitRank,
                    CNTKLib.SentinelValueForInferParamInitRank, 1),
                device, "timesParam");
            var timesFunction = CNTKLib.Times(timesParam, input, "times");

            int[] s2 = { outputDim };
            var plusParam = new Parameter(s2, 0.0f, device, "plusParam");
            return CNTKLib.Plus(plusParam, timesFunction, outputName);
        }
    }
}
