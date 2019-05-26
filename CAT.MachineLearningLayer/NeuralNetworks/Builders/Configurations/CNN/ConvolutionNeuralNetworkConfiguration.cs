using CAT.MachineLearningLayer.NeuralNetworks.Builders.Configurations.CNN.Models;
using CAT.MachineLearningLayer.NeuralNetworks.Enums;
using CNTK;
using System.Collections.Generic;

namespace CAT.MachineLearningLayer.ConvolutionNeuralNetwork.Configurations
{
    internal static class ConvolutionNeuralNetworkConfiguration
    {
        private static readonly ActivationFunction ConvolutionActivationFunction = ActivationFunction.ReLu;
        private static readonly PoolingType PoolingType = PoolingType.Max;

        public static ActivationFunction DenseActivationFunction = ActivationFunction.Tanh;

        public static IEnumerable<ConvolutionWithPoolingConfigurationModel> ConvolutionWithPoolingLayers
            = new List<ConvolutionWithPoolingConfigurationModel>
        {
                new ConvolutionWithPoolingConfigurationModel //Layer 1
                {
                    Convolution = new ConvolutionConfigurationModel
                    {
                        KernelHeight = 3,
                        KernelWidth = 3,
                        InputChannelsCount = 1,
                        OutFeatureMapCount = 4,
                        ActivationFunction = ConvolutionActivationFunction
                    },
                    Pooling = new PoolingConfigurationModel
                    {
                        WindowHeight = 2,
                        WindowWidth = 2,
                        StrideByHeight = 2,
                        StrideByWidth = 2,
                        PoolingType = PoolingType
                    }
                },
                new ConvolutionWithPoolingConfigurationModel //Layer 2
                {
                    Convolution = new ConvolutionConfigurationModel
                    {
                        KernelHeight = 3,
                        KernelWidth = 3,
                        InputChannelsCount = 4,
                        OutFeatureMapCount = 8,
                        ActivationFunction = ConvolutionActivationFunction
                    },
                    Pooling = new PoolingConfigurationModel
                    {
                        WindowHeight = 2,
                        WindowWidth = 2,
                        StrideByHeight = 2,
                        StrideByWidth = 2,
                        PoolingType = PoolingType
                    }
                },
                new ConvolutionWithPoolingConfigurationModel  //Layer 3
                {
                    Convolution = new ConvolutionConfigurationModel
                    {
                        KernelHeight = 3,
                        KernelWidth = 3,
                        InputChannelsCount = 8,
                        OutFeatureMapCount = 16,
                        ActivationFunction = ConvolutionActivationFunction
                    },
                    Pooling = new PoolingConfigurationModel
                    {
                        WindowHeight = 2,
                        WindowWidth = 2,
                        StrideByHeight = 2,
                        StrideByWidth = 2,
                        PoolingType = PoolingType
                    }
                },
                new ConvolutionWithPoolingConfigurationModel //Layer 4
                {
                    Convolution = new ConvolutionConfigurationModel
                    {
                        KernelHeight = 3,
                        KernelWidth = 3,
                        InputChannelsCount = 16,
                        OutFeatureMapCount = 32,
                        ActivationFunction = ConvolutionActivationFunction
                    },
                    Pooling = new PoolingConfigurationModel
                    {
                        WindowHeight = 2,
                        WindowWidth = 2,
                        StrideByHeight = 2,
                        StrideByWidth = 2,
                        PoolingType = PoolingType
                    }
                }
        };
    }
}
