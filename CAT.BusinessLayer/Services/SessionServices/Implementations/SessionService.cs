using System.Collections.Generic;
using System.Linq;
using CAT.BusinessLayer.Models.SessionModels;
using CAT.DataLayer.Models;
using CAT.DataLayer.Models.Enums;
using CAT.DataLayer.Repositories.DatabaseRepositories.Interfaces;

namespace CAT.BusinessLayer.Services.SessionServices.Implementations
{
    public class SessionService : ISessionService
    {
        private readonly IDatabaseRepository<TrainingSession> trainingRepository;
        private readonly IDatabaseRepository<TestSession> testRepository;

        public SessionService(
            IDatabaseRepository<TrainingSession> trainingRepository,
            IDatabaseRepository<TestSession> testRepository)
        {
            this.trainingRepository = trainingRepository;
            this.testRepository = testRepository;
        }

        public IEnumerable<SessionViewModel> GetSessions(User currentUser)
        {
            var result = new List<SessionViewModel>();
            var tests = testRepository.QueryableList().Where(x => x.User.Id == currentUser.Id);
            var trainings = trainingRepository.QueryableList().Where(x =>
                x.User.Id == currentUser.Id && x.Status != TrainingSessionStatus.InProgress);
            foreach (var testSession in tests)
            {
                result.Add(new SessionViewModel
                {
                    IsTest = true,
                    ReturnedEmotionType = testSession.ResultType.ToString(),
                    SelectedEmotionType = testSession.Type.ToString(),
                    Sources = new[] { testSession.Source },
                    StartDate = testSession.StartDate
                });
            }

            foreach (var trainingSession in trainings)
            {
                result.Add(new SessionViewModel
                {
                    IsTest = false,
                    SelectedEmotionType = trainingSession.EmotionType.ToString(),
                    Sources = trainingSession.TrainingSources.Select(x => x.SourceUrl).ToArray(),
                    StartDate = trainingSession.StartDate,
                    EndDate = trainingSession.EndDate,
                    Logs = trainingSession.TrainingLogs.Select(x=>x.Text).ToArray()
                });
            }

            return result.OrderByDescending(x => x.StartDate);
        }
    }
}
