using CAT.MachineLearningLayer.NeuralNetworks.Enums;
using CNTK;

namespace CAT.MachineLearningLayer.NeuralNetworks.Utils
{
    internal static class BuilderHelper
    {
        public static Function GetActivationFunction(ActivationFunction activationFunction, Variable networkLayer)
        {
            switch (activationFunction)
            {
                default:
                case ActivationFunction.None:
                    return networkLayer;
                case ActivationFunction.ReLu:
                    return CNTKLib.ReLU(networkLayer);
                case ActivationFunction.Sigmoid:
                    return CNTKLib.Sigmoid(networkLayer);
                case ActivationFunction.Tanh:
                    return CNTKLib.Tanh(networkLayer);
            }
        }
    }
}
