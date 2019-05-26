using System.Linq;
using CAT.DataLayer.Contextes;
using CAT.DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace CAT.DataLayer.Repositories.DatabaseRepositories
{
    public class TrainingRepository : BaseDatabaseRepository<TrainingSession>
    {
        public TrainingRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public override IQueryable<TrainingSession> QueryableList()
        {
            return DbContext.TrainingSessions.Include(x => x.TrainingSources).Include(x => x.TrainingLogs);
        }
    }
}
