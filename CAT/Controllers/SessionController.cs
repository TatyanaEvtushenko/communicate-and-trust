using System.Collections.Generic;
using CAT.BusinessLayer.Models.SessionModels;
using CAT.BusinessLayer.Services.SessionServices;
using CAT.BusinessLayer.Services.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace CAT.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class SessionController : Controller
    {
        private readonly IUserService userService;
        private readonly ISessionService sessionService;

        public SessionController(IUserService userService, ISessionService sessionService)
        {
            this.userService = userService;
            this.sessionService = sessionService;
        }

        [HttpGet("getSessions")]
        public IEnumerable<SessionViewModel> GetSessions(string currentUserName)
        {
            var currentUser = userService.GetUserByName(currentUserName);
            return sessionService.GetSessions(currentUser);
        }
    }
}
