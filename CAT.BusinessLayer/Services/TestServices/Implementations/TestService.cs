using System;
using System.Collections.Generic;
using CAT.BusinessLayer.Models.TestModels;
using CAT.BusinessLayer.Utils.Emotion;
using CAT.DataLayer.Models;
using CAT.DataLayer.Repositories.DatabaseRepositories.Interfaces;

namespace CAT.BusinessLayer.Services.TestServices.Implementations
{
    public class TestService : ITestService
    {
        private readonly IDatabaseRepository<TestSession> testRepository;

        public TestService(IDatabaseRepository<TestSession> testRepository)
        {
            this.testRepository = testRepository;
        }

        public void SaveResults(User currentUser, TestResult model)
        {
            var session = new TestSession
            {
                IsValid = model.ResultEmotion == model.SelectedEmotion,
                ResultType = EmotionUtil.GetEmotionType(model.ResultEmotion),
                Type = EmotionUtil.GetEmotionType(model.SelectedEmotion),
                StartDate = DateTime.Now,
                User = currentUser,
                TestLogs = new List<TestLog>(),
                Source = model.Source
            };
            testRepository.Add(session);
        }
    }
}
