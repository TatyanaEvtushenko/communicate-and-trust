using CAT.BusinessLayer.Services.SmileServices;
using CAT.BusinessLayer.Services.SmileServices.Interfaces;
using CAT.MachineLearningLayer.Detectors.EmotionDetectors;
using CAT.MachineLearningLayer.Detectors.EmotionDetectors.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CAT.Extensions
{
    public static class ServiceProviderExtensions
    {
        public static void AddProjectServices(this IServiceCollection services)
        {
            services.AddScoped<ISmileService, TestSmileService>();
        }

        public static void AddProjectUtils(this IServiceCollection services)
        {
            services.AddScoped<IEmotionDetector, EmotionDetector>();
        }

        public static void AddProjectRepositories(this IServiceCollection services)
        {
        }
    }
}
