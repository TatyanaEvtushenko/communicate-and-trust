using System.Collections.Generic;
using CAT.BusinessLayer.Models.DialogModels;
using CAT.BusinessLayer.Services.DialogServices;
using CAT.BusinessLayer.Services.MessageServices;
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
        private readonly IMessageService messageService;

        public DialogController(
            IUserService userService,
            IDialogService dialogService,
            IMessageService messageService)
        {
            this.userService = userService;
            this.dialogService = dialogService;
            this.messageService = messageService;
        }

        [HttpGet("getCurrentUserDialogs")]
        public IEnumerable<DialogListingViewModel> GetCurrentUserDialogs(string currentUserName)
        {
            var currentUserId = userService.GetUserIdByName(currentUserName);
            return dialogService.GetUserDialogs(currentUserId);
        }

        [HttpGet("getDialogWithUser")]
        public DialogViewModel GetDialogWithUser(string currentUserName, string userName)
        {
            var currentUserId = userService.GetUserIdByName(currentUserName);
            var userId = userService.GetUserIdByName(userName);
            return dialogService.GetDialog(currentUserId, userId);
        }

        [HttpPost("postMessage")]
        public bool PostMessage([FromBody]MessageViewModel model)
        {
            var currentUser = userService.GetUserByName(model.Author);
            var userId = userService.GetUserIdByName(model.To);
            messageService.PostMessage(
                model,
                currentUser,
                dialogService.GetDomainDialog(currentUser.Id, userId));

            return true;
        }

        [HttpGet("readAllMessages")]
        public bool ReadAllMessages(string currentUserName, string userName)
        {
            var currentUserId = userService.GetUserIdByName(currentUserName);
            var userId = userService.GetUserIdByName(userName);
            return messageService.ReadAllMessages(currentUserId, userId);
        }
    }
}
