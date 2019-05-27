using System.Linq;
using CAT.DataLayer.Contextes;
using CAT.DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace CAT.DataLayer.Repositories.DatabaseRepositories
{
    public class TrainingLogRepository:BaseDatabaseRepository<TrainingLog>
    {
        public TrainingLogRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public override IQueryable<TrainingLog> QueryableList()
        {
            return DbContext.TrainingLogs.Include(x => x.TrainingSession);
        }
    }
}
