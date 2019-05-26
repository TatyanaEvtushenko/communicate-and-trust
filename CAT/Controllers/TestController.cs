using CAT.BusinessLayer.Models.TestModels;
using CAT.BusinessLayer.Services.TestServices;
using CAT.BusinessLayer.Services.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace CAT.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        private readonly IUserService userService;
        private readonly ITestService testService;

        public TestController(IUserService userService, ITestService testService)
        {
            this.userService = userService;
            this.testService = testService;
        }

        [HttpPost("saveTestResults")]
        public void SaveTestResults([FromBody]TestResult model)
        {
            var currentUser = userService.GetUserByName(model.UserName);
            testService.SaveResults(currentUser, model);
        }
    }
}
