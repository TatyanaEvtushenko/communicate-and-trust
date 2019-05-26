using CAT.BusinessLayer.Models.TrainingModels;
using CAT.DataLayer.Models;

namespace CAT.BusinessLayer.Services.TrainingServices
{
    public interface ITrainingService
    {
        void SaveResults(User currentUser, TrainingSetupModel model);
        TrainingResultsModel GetCurrentSession(User currentUser);
    }
}
