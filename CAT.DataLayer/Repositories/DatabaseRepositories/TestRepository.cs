﻿using System.Linq;
using CAT.DataLayer.Contextes;
using CAT.DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace CAT.DataLayer.Repositories.DatabaseRepositories
{
    public class TestRepository : BaseDatabaseRepository<TestSession>
    {
        public TestRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public override IQueryable<TestSession> QueryableList()
        {
            return DbContext.TestSessions.Include(x => x.User);
        }
    }
}
