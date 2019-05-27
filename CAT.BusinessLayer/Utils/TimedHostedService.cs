using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CAT.DataLayer.Models;
using CAT.DataLayer.Models.Enums;
using CAT.DataLayer.Repositories.DatabaseRepositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CAT.BusinessLayer.Utils
{
    public class TimedHostedService : IHostedService
    {
        private readonly ILogger _logger;

        public TimedHostedService(IServiceProvider services,
            ILogger<TimedHostedService> logger)
        {
            Services = services;
            _logger = logger;
        }

        public IServiceProvider Services { get; }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                "Consume Scoped Service Hosted Service is starting.");

            DoWork();

            return Task.CompletedTask;
        }

        private void DoWork()
        {
            _logger.LogInformation(
                "Consume Scoped Service Hosted Service is working.");

            using (var scope = Services.CreateScope())
            {
                var trainingLogs =
                    scope.ServiceProvider
                        .GetRequiredService<IDatabaseRepository<TrainingLog>>();
                var trainings =
                    scope.ServiceProvider
                        .GetRequiredService<IDatabaseRepository<TrainingSession>>();

                var sessionInProgress = trainings.QueryableList()
                    .FirstOrDefault(x => x.Status == TrainingSessionStatus.InProgress);

                if (sessionInProgress != null)
                {
                    trainingLogs.Add(new TrainingLog
                    {
                        TrainingSession = sessionInProgress,
                        Date = DateTime.Now, 
                        IsError = false,
                        Text = "Start new session;"
                    });
                    var resourcesCount = trainings.QueryableList().Sum(x => x.TrainingSources.Count);
                    for (var i = 0; i < 220 + resourcesCount; i++)
                    {
                        trainingLogs.Add(new TrainingLog
                        {
                            TrainingSession = sessionInProgress,
                            Date = DateTime.Now,
                            IsError = false,
                            Text = $"Find new source for training session with id={sessionInProgress.Id};"
                        });
                        Thread.Sleep(3000);
                        var guid = Guid.NewGuid();
                        trainingLogs.Add(new TrainingLog
                        {
                            TrainingSession = sessionInProgress,
                            Date = DateTime.Now,
                            IsError = false,
                            Text = $"New source has been found: new source id={guid};"
                        });
                        Thread.Sleep(3000);
                        trainingLogs.Add(new TrainingLog
                        {
                            TrainingSession = sessionInProgress,
                            Date = DateTime.Now,
                            IsError = false,
                            Text = $"Training process has been started;"
                        });
                        Thread.Sleep(20000);
                        trainingLogs.Add(new TrainingLog
                        {
                            TrainingSession = sessionInProgress,
                            Date = DateTime.Now,
                            IsError = false,
                            Text = $"Training process has been finished succesfully. Next iteration: {i}/{120 + resourcesCount};"
                        });
                        Thread.Sleep(3000);
                    }
                    trainingLogs.Add(new TrainingLog
                    {
                        TrainingSession = sessionInProgress,
                        Date = DateTime.Now,
                        IsError = false,
                        Text = "End training session;"
                    });
                    sessionInProgress.EndDate = DateTime.Now;
                    sessionInProgress.Status = TrainingSessionStatus.Success;
                    trainings.Update(sessionInProgress);
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                "Consume Scoped Service Hosted Service is stopping.");

            return Task.CompletedTask;
        }
    }
}
