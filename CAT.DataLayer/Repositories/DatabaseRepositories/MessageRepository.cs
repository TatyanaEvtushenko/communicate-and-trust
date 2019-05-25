using System.Linq;
using CAT.DataLayer.Contextes;
using CAT.DataLayer.Models;

namespace CAT.DataLayer.Repositories.DatabaseRepositories
{
    public class MessageRepository : BaseDatabaseRepository<Message>
    {
        public MessageRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public override IQueryable<Message> QueryableList()
        {
            return DbContext.Messages;
        }
    }
}
