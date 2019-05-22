using CNTK;

namespace CAT.MachineLearningLayer.NeuralNetworks.Models
{
    internal class NetworkBuildOutput
    {
        public Variable Input { get; set; }

        public Variable Labels { get; set; }

        public Function ScaledInput { get; set; }

        public Function ClassifierOutput { get; set; }

        public Function TrainingLoss { get; set; }

        public Function Prediction { get; set; }
    }
}
