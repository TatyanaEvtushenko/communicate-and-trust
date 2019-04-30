using CAT.BusinessLayer.Options;
using CAT.BusinessLayer.Services.AccountServices;
using CAT.BusinessLayer.Services.AccountServices.Interfaces;
using CAT.BusinessLayer.Services.FileServices;
using CAT.BusinessLayer.Services.FileServices.Interfaces;
using CAT.BusinessLayer.Services.SmileServices;
using CAT.BusinessLayer.Services.SmileServices.Interfaces;
using CAT.DataLayer.Models;
using CAT.DataLayer.Repositories.DatabaseRepositories;
using CAT.DataLayer.Repositories.DatabaseRepositories.Interfaces;
using CAT.MachineLearningLayer.Detectors.EmotionDetectors;
using CAT.MachineLearningLayer.Detectors.EmotionDetectors.Interfaces;
using CAT.MachineLearningLayer.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CAT.Extensions
{
    public static class ServiceProviderExtensions
    {
        public static void AddProjectOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();
            services.Configure<CascadeOption>(configuration.GetSection("Cascades"));
            services.Configure<CloudinaryOption>(configuration.GetSection("Cloudinary"));
        }

        public static void AddProjectServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ISmileService, TestSmileService>();
            services.AddScoped<IImageFileService, CloudinaryService>();
        }

        public static void AddProjectUtils(this IServiceCollection services)
        {
            services.AddScoped<IEmotionDetector, EmotionDetector>();
        }

        public static void AddProjectRepositories(this IServiceCollection services)
        {
            services.AddScoped<IDatabaseRepository<User>, UserRepository>();
        }
    }
}
