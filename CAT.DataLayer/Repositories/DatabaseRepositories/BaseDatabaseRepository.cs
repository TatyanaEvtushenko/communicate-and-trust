using System;
using System.Linq;
using CAT.DataLayer.Contextes;
using CAT.DataLayer.Repositories.DatabaseRepositories.Interfaces;

namespace CAT.DataLayer.Repositories.DatabaseRepositories
{
    public abstract class BaseDatabaseRepository<T> : IDatabaseRepository<T>
        where T: class
    {
        private readonly ApplicationDbContext dbContext;

        protected BaseDatabaseRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public T GetFirst(Func<T, bool> predicate)
        {
            var entity = dbContext.Set<T>().FirstOrDefault(predicate);
            return entity;
        }

        public void Add(T entity)
        {
            dbContext.Set<T>().Add(entity);
            dbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            dbContext.Set<T>().Update(entity);
            dbContext.SaveChanges();
        }
    }
}
