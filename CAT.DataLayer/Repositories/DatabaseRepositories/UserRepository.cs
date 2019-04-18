using CAT.DataLayer.Contextes;
using CAT.DataLayer.Models;

namespace CAT.DataLayer.Repositories.DatabaseRepositories
{
    public class UserRepository : BaseDatabaseRepository<User>
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
