using CNTK;

namespace CAT.MachineLearningLayer.NeuralNetworks.Models
{
    internal class PreparedDataInfo
    {
        public MinibatchSource MinibatchSource { get; set; }

        public StreamInformation FeatureStreamInfo { get; set; }

        public StreamInformation LabelStreamInfo { get; set; }

        public PreparedDataInfo(string preparedDataPath, string featureStreamName, 
            string labelsStreamName, int imageSize, int numClasses, ulong epochSize)
        {
            MinibatchSource = GetMinibatchSource(preparedDataPath, featureStreamName, labelsStreamName, imageSize,
                numClasses, epochSize);
            FeatureStreamInfo = MinibatchSource.StreamInfo(featureStreamName);
            LabelStreamInfo = MinibatchSource.StreamInfo(labelsStreamName);
        }

        private MinibatchSource GetMinibatchSource(string preparedDataPath, string featureStreamName, 
            string labelsStreamName, int imageSize, int numClasses, ulong epochSize)
        {
            var streamConfigs = new[]
            {
                new StreamConfiguration(featureStreamName, imageSize),
                new StreamConfiguration(labelsStreamName, numClasses)
            };
            var minibatchSource = MinibatchSource.TextFormatMinibatchSource(preparedDataPath, streamConfigs, epochSize);
            return minibatchSource;
        }
    }
}
