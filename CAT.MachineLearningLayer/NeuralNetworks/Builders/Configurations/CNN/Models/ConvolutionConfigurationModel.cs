using CAT.MachineLearningLayer.NeuralNetworks.Enums;

namespace CAT.MachineLearningLayer.NeuralNetworks.Builders.Configurations.CNN.Models
{
    internal class ConvolutionConfigurationModel
    {
        public int KernelWidth { get; set; }

        public int KernelHeight { get; set; }

        public int InputChannelsCount { get; set; }

        public int OutFeatureMapCount { get; set; }

        public ActivationFunction ActivationFunction { get; set; }
    }
}
