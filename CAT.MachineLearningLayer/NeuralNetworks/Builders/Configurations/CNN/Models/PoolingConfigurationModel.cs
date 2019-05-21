using CNTK;

namespace CAT.MachineLearningLayer.NeuralNetworks.Builders.Configurations.CNN.Models
{
    internal class PoolingConfigurationModel
    {
        public int WindowWidth { get; set; }
                   
        public int WindowHeight { get; set; }

        public int StrideByWidth { get; set; }

        public int StrideByHeight { get; set; }

        public PoolingType PoolingType { get; set; }
    }
}
