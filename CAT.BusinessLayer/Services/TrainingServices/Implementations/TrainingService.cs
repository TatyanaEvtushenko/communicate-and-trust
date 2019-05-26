using System;
using System.Collections.Generic;
using System.Linq;
using CAT.BusinessLayer.Models.TrainingModels;
using CAT.BusinessLayer.Utils.Emotion;
using CAT.DataLayer.Models;
using CAT.DataLayer.Models.Enums;
using CAT.DataLayer.Repositories.DatabaseRepositories.Interfaces;

namespace CAT.BusinessLayer.Services.TrainingServices.Implementations
{
    public class TrainingService : ITrainingService
    {
        private readonly IDatabaseRepository<TrainingSession> trainingRepository;

        public TrainingService(IDatabaseRepository<TrainingSession> trainingRepository)
        {
            this.trainingRepository = trainingRepository;
        }

        public void SaveResults(User currentUser, TrainingSetupModel model)
        {
            var session = new TrainingSession
            {
                StartDate = model.StartDate,
                User = currentUser,
                TrainingLogs = new List<TrainingLog>(),
                Status = TrainingSessionStatus.InProgress,
                EmotionType = EmotionUtil.GetEmotionType(model.SelectedEmotion)
            };
            var sources = model.Sources.Select(x => new TrainingSource
            {
                SourceUrl = x,
                TrainingSession = session
            });
            session.TrainingSources = sources.ToList();
            trainingRepository.Add(session);


            // HERE WE SHOULD START LOGGING PROCESS
        }

        public TrainingResultsModel GetCurrentSession(User currentUser)
        {
            var model = trainingRepository.QueryableList().FirstOrDefault(x =>
                x.User.Id == currentUser.Id && x.Status == TrainingSessionStatus.InProgress);
            if (model == null)
            {
                return null;
            }

            return new TrainingResultsModel
            {
                UserName = currentUser.UserName,
                Logs = model.TrainingLogs.Select(x => x.Text).ToArray(),
                Percents = 20,
                SelectedEmotion = model.EmotionType.ToString().ToLower(),
                Sources = model.TrainingSources.Select(x => x.SourceUrl).ToArray(),
                StartDate = model.StartDate
            };
        }
    }
}
