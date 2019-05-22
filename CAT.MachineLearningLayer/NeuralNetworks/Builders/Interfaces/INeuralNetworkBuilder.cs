using CAT.MachineLearningLayer.NeuralNetworks.Models;
using CNTK;

namespace CAT.MachineLearningLayer.NeuralNetworks.Builders.Interfaces
{
    internal interface INeuralNetworkBuilder
    {
        NetworkBuildOutput Build(DeviceDescriptor device, string featureStreamName, string labelsStreamName,
            string classifierName, int numClasses, int[] imageDim);
    }
}
