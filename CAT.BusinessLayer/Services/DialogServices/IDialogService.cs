using System.Collections.Generic;
using CAT.BusinessLayer.Models.DialogModels;
using CAT.DataLayer.Models;

namespace CAT.BusinessLayer.Services.DialogServices
{
    public interface IDialogService
    {
        IEnumerable<DialogListingViewModel> GetUserDialogs(string userId);

        DialogViewModel GetDialog(string firstUserId, string secondUserId);

        Dialog GetDomainDialog(string firstUserId, string secondUserId);
    }
}
