using CAT.BusinessLayer.Options;
using CAT.BusinessLayer.Services.AccountServices;
using CAT.BusinessLayer.Services.AccountServices.Interfaces;
using CAT.BusinessLayer.Services.DialogServices;
using CAT.BusinessLayer.Services.DialogServices.Implementations;
using CAT.BusinessLayer.Services.ImageStoreServices;
using CAT.BusinessLayer.Services.ImageStoreServices.Implementations;
using CAT.BusinessLayer.Services.MessageServices;
using CAT.BusinessLayer.Services.MessageServices.Implementations;
using CAT.BusinessLayer.Services.SessionServices;
using CAT.BusinessLayer.Services.SessionServices.Implementations;
using CAT.BusinessLayer.Services.SmileServices;
using CAT.BusinessLayer.Services.SmileServices.Interfaces;
using CAT.BusinessLayer.Services.TestServices;
using CAT.BusinessLayer.Services.TestServices.Implementations;
using CAT.BusinessLayer.Services.TrainingServices;
using CAT.BusinessLayer.Services.TrainingServices.Implementations;
using CAT.BusinessLayer.Services.UserServices;
using CAT.BusinessLayer.Services.UserServices.Implementations;
using CAT.BusinessLayer.Utils;
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
        public static void AddProjectServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ISmileService, TestSmileService>();
            services.AddScoped<IImageStoreService, CloudinaryService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IDialogService, DialogService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<ITestService, TestService>();
            services.AddScoped<ITrainingService, TrainingService>();
            services.AddScoped<ISessionService, SessionService>();
            services.AddHostedService<TimedHostedService>();
        }

        public static void AddProjectUtils(this IServiceCollection services)
        {
            services.AddScoped<IEmotionDetector, EmotionDetector>();
        }

        public static void AddProjectRepositories(this IServiceCollection services)
        {
            services.AddScoped<IDatabaseRepository<User>, UserRepository>();
            services.AddScoped<IDatabaseRepository<Dialog>, DialogRepository>();
            services.AddScoped<IDatabaseRepository<Message>, MessageRepository>();
            services.AddScoped<IDatabaseRepository<TestSession>, TestRepository>();
            services.AddScoped<IDatabaseRepository<TrainingSession>, TrainingRepository>();
            services.AddScoped<IDatabaseRepository<TrainingLog>, TrainingLogRepository>();
        }

        public static void AddProjectOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<CascadeOption>(configuration.GetSection("Cascades"));
            services.Configure<CloudinarySettings>(configuration.GetSection("CloudinarySettings"));
            services.Configure<NeuralNetworkOption>(configuration.GetSection("NeuralNetwork"));
        }
    }
}
