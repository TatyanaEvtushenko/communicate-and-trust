using CAT.BusinessLayer.Models.TrainingModels;
using CAT.BusinessLayer.Services.TrainingServices;
using CAT.BusinessLayer.Services.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace CAT.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TrainingController : Controller
    {
        private readonly IUserService userService;
        private readonly ITrainingService trainingService;

        public TrainingController(IUserService userService, ITrainingService trainingService)
        {
            this.userService = userService;
            this.trainingService = trainingService;
        }

        [HttpPost("setupTrainingSession")]
        public void SetupTrainingSession([FromBody]TrainingSetupModel model)
        {
            var currentUser = userService.GetUserByName(model.UserName);
            trainingService.SaveResults(currentUser, model);
        }

        [HttpGet("getTrainingSession")]
        public TrainingResultsModel GetTrainingSession(string userName)
        {
            var currentUser = userService.GetUserByName(userName);
            return trainingService.GetCurrentSession(currentUser);
        }
    }
}
