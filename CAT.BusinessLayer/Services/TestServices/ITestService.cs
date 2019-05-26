using CAT.BusinessLayer.Models.TestModels;
using CAT.DataLayer.Models;

namespace CAT.BusinessLayer.Services.TestServices
{
    public interface ITestService
    {
        void SaveResults(User currentUser, TestResult model);
    }
}
