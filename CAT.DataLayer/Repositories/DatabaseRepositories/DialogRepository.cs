using System;
using System.Linq;
using CAT.DataLayer.Contextes;
using CAT.DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace CAT.DataLayer.Repositories.DatabaseRepositories
{
    public class DialogRepository : BaseDatabaseRepository<Dialog>
    {
        public DialogRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public override Dialog GetFirst(Func<Dialog, bool> predicate)
        {
            var entity = DbContext.Dialogs
                .Include(x => x.UserDialogs).ThenInclude(x => x.User)
                .Include(x => x.Messages)
                .FirstOrDefault(predicate);
            return entity;
        }

        public override IQueryable<Dialog> QueryableList()
        {
            return DbContext.Dialogs.Include(x => x.UserDialogs).ThenInclude(x => x.User).Include(x => x.Messages);
        }
    }
}
