using System.Linq;
using CAT.DataLayer.Contextes;
using CAT.DataLayer.Models;

namespace CAT.DataLayer.Repositories.DatabaseRepositories
{
    public class DialogRepository : BaseDatabaseRepository<Dialog>
    {
        public DialogRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public override IQueryable<Dialog> QueryableList()
        {
            return DbContext.Dialogs;
        }
    }
}
