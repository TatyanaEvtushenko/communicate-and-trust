using System.Collections.Generic;
using CAT.BusinessLayer.Models.DialogModels;

namespace CAT.BusinessLayer.Services.DialogServices
{
    public interface IDialogService
    {
        IEnumerable<DialogListingViewModel> GetUserDialogs(string userId);

        DialogViewModel GetDialog(string firstUserId, string secondUserId);
    }
}
