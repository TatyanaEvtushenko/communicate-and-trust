using System.Collections.Generic;
using CAT.BusinessLayer.Models.SessionModels;
using CAT.DataLayer.Models;

namespace CAT.BusinessLayer.Services.SessionServices
{
    public interface ISessionService
    {
        IEnumerable<SessionViewModel> GetSessions(User currentUser);
    }
}
