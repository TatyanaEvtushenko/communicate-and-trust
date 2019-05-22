using System.Collections.Generic;
using CAT.BusinessLayer.Models.DialogModels;
using CAT.BusinessLayer.Services.DialogServices;
using CAT.BusinessLayer.Services.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace CAT.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class DialogController : Controller
    {
        private readonly IUserService userService;
        private readonly IDialogService dialogService;

        public DialogController(IUserService userService, IDialogService dialogService)
        {
            this.userService = userService;
            this.dialogService = dialogService;
        }

        [HttpGet("getCurrentUserDialogs")]
        public IEnumerable<DialogListingViewModel> GetCurrentUserDialogs()
        {
            var currentUserId = userService.GetUserIdByName(User.Identity.Name);
            return dialogService.GetUserDialogs(currentUserId);
        }

        [HttpGet("getDialogWithUser")]
        public DialogViewModel GetDialogWithUser(string userName)
        {
            var currentUserId = userService.GetUserIdByName(User.Identity.Name);
            var userId = userService.GetUserIdByName(userName);
            return dialogService.GetDialog(currentUserId, userId);
        }
    }
}
